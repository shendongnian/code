    using UnityEngine;
    using System.Collections;
    
    public class TestScript: MonoBehaviour {
    
        public GameObject camera;
        public GameObject gameObject;
        public int rotationAmount = 1;
        // Update is called once per frame
        void Update () {
    
            Vector3 camera = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -gameObject.transform.position.x);
    
            if(gameObject.transform.position > 0) {
                camera.x -= rotationAmount;
            }
    
            camera.transform.position = camera;
        }
    }
