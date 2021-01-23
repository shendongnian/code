    using UnityEngine;
    using System.Collections;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    [ExecuteInEditMode]
    public class SceneManager : MonoBehaviour
    {
        // not best idea to have it static 
        public static bool userClickedNextButton;
        protected const int MAX = 50;
        private List<int> scenes = new List<int>();
        void Start() {
            // Initialize the list with levels
            scenes = new List<int>(IEnumberable<int>.Range(1,MAX)); // This creates a list with values from 1 to 50
        }
        void Update()
        {
            if (userClickedNextButton)
            {
                if(scenes.Count == 0) {
                    // No scenes left, quit
                    Application.Quit();
                }
                // Get a random index from the list of remaining level 
                int randomIndex = Random.Range(0, scenes.Count);
                int level = scenes[randomIndex];
                scenes.RemoveAt(randomIndex); // Removes the level from the list
                Application.LoadLevel(level);
                
                userClickedNextButton = false;
            }
        }
    }
