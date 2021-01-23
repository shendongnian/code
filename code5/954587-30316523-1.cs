    	using System.Collections;
    	using UnityEngine;
    	public class rayoPrueba : MonoBehaviour {
    	void start () {print("entro"); }
    	void Update() {
    
    			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    			if (Physics.Raycast(ray, 100))
    				print("Si le jue");
    			}
    		}
    	
