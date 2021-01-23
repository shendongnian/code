    bool playerInView = false;
    void Update()
    {
        playerInView = false;
        foreach (RaycastHit hit in eyes.hits)
        {
            if (hit.transform && hit.transform.tag == "Player")
            {
                playerInView = true;
            }
        }
        if (playerInView)
        {
            print ("Detected");
        }
    }
    void OnGUI()
    {
        if (!playerInView)
        {
            GUI.Box (new Rect (10, 10, 100, 90), "Loader Menu");
        }
        ...
    }
