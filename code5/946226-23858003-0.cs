    using UnityEngine;
    using System.Collections;
    public class NewBehaviourScript : MonoBehaviour {
    
        int Hunger;
    
        // Use this for initialization
        void Start () {
            //Declare intager Hunger
            Hunger = 100; 
            GUI.Box(new Rect(10,10,100,90), "Stats");
    
            GUI.Label (Rect (10,40,100,20), GUI.tooltip,GUIContent("Hunger", Hunger));
        }
    
        // Update is called once per frame
        IEnumerator Update () {
            //Every ten seconds Hunger goes down by one.
            Hunger = Hunger - 1;
            yield WaitForSeconds = 10;
        }
    
    };
