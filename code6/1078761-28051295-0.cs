    RaycastHit hittenGo; // Declare up this variable
    void Update()
    {
      playerInView = false;
      foreach (RaycastHit hit in eyes.hits)
      {
        if (hit.transform && hit.transform.tag == "Player")
        {
            hittenGo = hit;
            playerInView = true;
        }
      }
    }
    void OnGUI()
    {
      if (playerInView)
      {
        GUI.Box (new Rect (10, 10, 160, 60), "Title");
        GUI.Label( new Rect(10, 10, 160, 60), hittenGo.collider.gameObject.name);
      }
    }
