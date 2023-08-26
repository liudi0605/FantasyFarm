using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform[] _scores;
    [SerializeField] private int _index;
    [SerializeField] private float radiusScorePosition;
    [SerializeField] private float heightScorePosition;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect(inventory);

            _scores[_index].gameObject.SetActive(true);
            _scores[_index].position = transform.position + new Vector3(Random.Range(-radiusScorePosition,radiusScorePosition), 
                heightScorePosition, 
                Random.Range(-radiusScorePosition, radiusScorePosition));

            if (_index < 4)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }

            other.gameObject.SetActive(false);
        }
    }
}
