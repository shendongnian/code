    using UnityEngine;
    using System.Collections;
    public class KillBad : MonoBehaviour {
        System.Random r;
        int rInt;
        int range = 100;
        // Use this for initialization
        public int points = 0;
        void Start () {
            r = new System.Random ();
            rInt = r.Next(-50, 50);
    } 
