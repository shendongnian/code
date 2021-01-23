    using UnityEngine;
    using UnityEngine.UI;
    
    public class TurnManager : MonoBehaviour 
    {
    	public Text text;
    	 
    	void Update()
    	{
    		text.text = PlayerController.Turns.ToString();
    	}
    }
