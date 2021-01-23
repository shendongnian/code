    using UnityEngine;
    using System.Collections;
    public class NewBehaviourScript : MonoBehaviour {
    
        int Hunger;
    
        void Start () {
            Hunger = 100; 
            GUI.Box(new Rect(10,10,100,90), "Stats");
    
            GUI.Label (Rect (10,40,100,20), GUI.tooltip,GUIContent("Hunger", Hunger));
        }
    
        IEnumerator Update () {
            //Every ten seconds Hunger goes down by one.
            Hunger = Hunger - 1;
            yield new WaitForSeconds(10);
        }
    
    };
