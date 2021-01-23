    using UnityEngine;
    using System.Collections;
    
    public class myscript : MonoBehaviour {
        public Transform platform;
        public float z = 0.0f;
        private GameObject _obj;
        void Update () 
        {
            float c_z=0.0f;
            _obj = Instantiate(platform,new Vector3(z++,0,0),Quaternion.identity) as GameObject;
            Camera.main.transform.Translate (0,0,c_z=c_z+0.1f);
        }
    }
