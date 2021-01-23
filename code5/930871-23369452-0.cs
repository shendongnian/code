    using UnityEngine;
    using System.Collections;
    public class DeleteMe : MonoBehaviour 
    {
        public GameObject Up;
        public GameObject Down;
        public GameObject Left;
        public GameObject Right;
    	void Start( ) 
        {
    	
    	}
    	
    	// Update is called once per frame
    	void Update( ) 
        {
            Move( gameObject );
            Move( Down );
    	}
        private void Move( GameObject obj )
        {
            Vector3 position = obj.transform.position;
            position.y += UnityEngine.Time.deltaTime;
            obj.transform.position = position;
        }
    }
