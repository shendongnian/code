        function Update()
    {
        longClick = false;     //Remove this
        shortClick = false;    //Remove this
        if ( Input.GetMouseButtonDown (0) )
        {
               t0 = Time.time ;
               longClick = false;
                shortClick = false;
        }
     
        if ( Input.GetMouseButtonUp(0)  (Time.time -  t0) < 0.2 )
       {
            longClick = false;
            shortClick = true;
       }
     
        if ( Input.GetMouseButtonUp(0)  (Time.time -  t0) > 0.2 )
       {
          longClick = true;
          shortClick = false;
       }
           //Process Movement
    }
