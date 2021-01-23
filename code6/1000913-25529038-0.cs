    System.Timers.Timer GetMousePosition = new System.Timers.Timer();
    GetMousePosition.Interval=5000;
    GetMousePosition.Elapsed += new System.Timers.ElapsedEventHandler(GetMousePosition_Elapsed);
    
    void GetMousePosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      POINT CursorPositon= GetCursorPosition()
      textBox1.AppentText("Cursor is in X Coordinate: "+CursorPositon.X.ToString()+" and Y-Coordinate "+ CursorPositon.X.ToString());
    }
        
    
 
 
