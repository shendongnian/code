    void OnTriggerEnter2D(Collider2D col) // Collider1 Script
    {
      if ((col.gameObject.tag == "ball2"))
      {
          firstcollider = true;
      }
    }
    void OnTriggerEnter2D(Collider2D col) // Collider2 Script
    {
     if (Collider1.firstcollider == true ) && (col.gameObject.tag == "ball"))
     {
         Application.LoadLevel("Main");
     }
    }
