    using UnityEngine;
    using System.Collections;
    
    public class qwe : MonoBehaviour {
    	
    	void  Update (){
    		float xP = Input.GetAxis ("Horizontal")*Time.deltaTime * 20;
    		Vector3 xe = new Vector3(xP,0,0);
    		transform.Translate(xe);
    		float x = Mathf.Clamp (transform.position.x, -10, 10);
    		transform.position = new Vector3(x,transform.position.y,transform.position.z);
    	}
    }
