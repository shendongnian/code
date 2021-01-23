    using UnityEngine;
    using System.Collections;
    public class NewBehaviourScript : MonoBehaviour {
    
        int Hunger;
    
        void Start () {
            Hunger = 100; 
            GUI.Box(new Rect(10,10,100,90), "Stats");
    
            GUI.Label (Rect (10,40,100,20), GUI.tooltip,GUIContent("Hunger", Hunger));
            StartCoroutine(TickHunger());
        }
    
        IEnumerator TickHunger () {
            while(Hunger > 0)
            {
               //Every ten seconds Hunger goes down by one.
               Hunger = Hunger - 1;
               yield return new WaitForSeconds(10);
            }
        }
    
    };
