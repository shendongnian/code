    using UnityEngine;
    using System.Collections;
    public class PlayerPrefsScript : MonoBehaviour {
	public int amountOfCoins;
	
	void Start () {
		amountOfCoins = PlayerPrefs.GetInt("TotalCoinsPlayerPrefs");
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, 100, 50), "Coins: " + amountOfCoins)) {
			amountOfCoins++;	
		}
	}
	void OnDestroy(){
		PlayerPrefs.SetInt ("TotalCoinsPlayerPrefs", amountOfCoins);
	}
    }
