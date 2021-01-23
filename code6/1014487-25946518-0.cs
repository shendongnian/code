    using UnityEngine;
    using System.Collections;
    
    public class Tweener : MonoBehaviour {
    	public float tweenStopDistance = 0.2f;
    	public float tweenSpeed = 2.0f;
    	public Vector3 targetPosition = new Vector3();
    	
    	void Start () {
    		targetPosition = transform.position;
    	}
    	
    	void Update () {
    		if((transform.position - targetPosition).magnitude > tweenStopDistance){
		
			transform.position += tweenSpeed * (targetPosition - transform.position).normalized * Time.deltaTime;
    		}
    	}
    }
