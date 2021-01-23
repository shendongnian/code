    public class MyGUI : MonoBehaviour {
        void OnGUI()
        {
            if (GUI.Button(new Rect(400, 300, 60, 25), "Black"))
            {
                Debug.Log("colour black");
                PlayerPrefs.SetInt("Colour", 2);
            }
            if (GUI.Button(new Rect(400, 330, 60, 25), "Grey"))
            {
                Debug.Log("colour grey");
                PlayerPrefs.SetInt("Colour", 1);
            }
            if (GUI.Button(new Rect(400, 360, 60, 25), "Orange Border"))
            {
                Debug.Log("colour OGrey");
                PlayerPrefs.SetInt("Colour", 3);
            }
        }
    }  
