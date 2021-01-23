    using UnityEngine;
    using System.Collections;
    public class UI : MonoBehaviour {
	public Texture2D[] parts;
	public Texture2D[] extra;
	public string[] actions;
	int buttonHeight, buttonWidth;
	int x, y;
	int width, height;
	
	void OnGUI ()
	{
		for (int i = 0; i < parts.Length; ++i) 
		{
			if (GUI.Button (new Rect (x - 35, i * (height + 97), width + 300, height + 90), parts [i]))
				Execute(actions[i]);
			//if (GUI.Button (new Rect (0, i * (buttonHeight + 20), buttonWidth + 100, buttonHeight + 100), textures [i]))
		}
		for (int x = 0; x < extra.Length; ++x) 
		{
			if (GUI.Button (new Rect (x + 800, x * (height + 140), width + 300, height + 120), extra [x]))
				
				Debug.Log ("Clicked button " + x);
			if (extra [0] && Input.GetButtonDown ("Jump")) 
			{
				Application.CaptureScreenshot ("Screenshot.png");
				Debug.Log ("Screen captured");
			}
		}
	}
	void Execute(string action) {
		switch (action) {
		case "exit":
			Application.Quit();
			break;
		case "next":
			// Load next level..
			Debug.Log("next");
			break;
		}
	}
}
