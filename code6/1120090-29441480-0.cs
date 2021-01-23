    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    public class MainLab : MonoBehaviour, IPointerClickHandler {
	// Use this for initialization
    
	    void Start () {
        	
	}
        public void OnPointerClick(PointerEventData eventData)
        {
        
            Debug.Log("Hello");
        }
    }
