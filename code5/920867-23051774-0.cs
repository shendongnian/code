    using UnityEngine;
    public class showMessage : MonoBehaviour
    {
        private bool startLap;
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                startLap = true;
            }
        }
        void OnGUI()
        {
            if (startLap)
            {
                if (GUI.Button(new Rect(100, 100, 500, 40), "Help! I lost my car. Find it through this maze for me?"))
                {
                    Debug.Log("Door Works!");
                    startLap = false;
                }
            }
        }
    }
