    using UnityEngine;
    using System.Collections;
    public class BallScript : MonoBehaviour {
	    private Vector3 randomDirection = Vector3.zero;
	    void Start () {
		    randomDirection = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
	    }
	    void OnMouseDown() {
		    Debug.Log ("Destroyed because out of click");
		    Destroy(gameObject);
	    }
	    void OnBecameInvisible () {
		    Debug.Log ("Destroyed because out of bounds");
		    Destroy(gameObject);
	    }
	    void Update () {
		    transform.Translate(randomDirection * Time.deltaTime);
	    }
    }
