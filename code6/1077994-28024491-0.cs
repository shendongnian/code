    void Update()
        {
            bool playerInView = false;
            foreach (RaycastHit hit in eyes.hits)
            {
                if (hit.transform && hit.transform.tag == "Player")
                {
                    playerInView = true;
                }
            }
            if (playerInView)
            {
                print("Detected");
            }
            else
            {
                OnGUI();
            }
        }
        void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");
        }
