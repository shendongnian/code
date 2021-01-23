    void Update()
    {
       if(Input.GetButton("Fire1"))
       {
           if (ammoCount > 0)
           {
               ammoCount--;
               // do raycast and so on
           }
       }
    }
