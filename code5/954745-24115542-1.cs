    public void MyFlickeringFunction()
     {
         try
         {
             SuspendDrawing(this);
             /*Your code goes here...*/
         }
         finally
         {
              ResumeDrawing(this)
         }
     }
