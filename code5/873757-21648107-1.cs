    using UnityEngine;
    using System.Collections;
    
    public class Example : MonoBehaviour {
        private GameObject target;
        void Start() {
            target = GameObject.FindWithTag("Player");
        }
    }
