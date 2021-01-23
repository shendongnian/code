    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class BulletCountScript : MonoBehaviour { 
        public CannonScript cannon;
        Text text;
        void Start () {
            text = GetComponent<Text> ();
        }
        void Update () {
            text.text = cannon.bullets.ToString(); //display the number of bullets
        }
    }
