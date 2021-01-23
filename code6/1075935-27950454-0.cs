     //Main Update
     if (Keyboard.GetState().IsKeyDown(key))
         myObject.Wait();
     else
         myObject.Continue();
    
     //Other object
     public void Wait()
     {
        waiting = true;
     }
    
     public void Continue()
     {
         waiting = false;
     }
    
     public void Update()
     {
          if (!waiting)
          {
             //Update state
           }
     }
