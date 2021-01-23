    using UnityEngine;
    using System.Collections;
    public class ReadOnlyTest : MonoBehaviour {
        
        public string part1 = "alpha";  // change these values in the editor and 
        public string part2 = "beta";  // see the output of the readonly variable "combined"
        
        public readonly string combined;
        
        // just assign to readonly vars.
        public readonly string guid = System.Guid.NewGuid().ToString();
        public readonly float readOnlyFloat = 2.0f;
        
        
        public class ReadOnlyContainer {
            public readonly int readOnlyInt;
            public readonly float readOnlyFloat;
            public readonly string readOnlyString;
            
            public ReadOnlyContainer(int _int, float _flt, string _str) {
                readOnlyInt = _int;
                readOnlyFloat = _flt;
                readOnlyString = _str;
            }
            
            public override string ToString() {
                return string.Format("int:{0} float:{1} string:{2}", readOnlyInt, readOnlyFloat, readOnlyString);
            }
        }
        
        public ReadOnlyTest() {
            combined = part1 + part2;
        }
        
        public ReadOnlyContainer container;
        
        void Awake() {
            if (container == null) {
                container = new ReadOnlyContainer(Random.Range(-100,100), Time.realtimeSinceStartup, System.Guid.NewGuid().ToString());
            }
        }
        
        void Start () {
            Debug.Log(container.ToString());
            
            Debug.Log("combine1: " + combined);
            
            Debug.Log("guid: " + guid);
        }   
    }
