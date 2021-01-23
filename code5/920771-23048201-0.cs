    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Point mousePos = MousePosition;
        
        if (mousePos == previousPosition)
            return;
        
        // .. your other code here        
        previousPosition = mousePos;
    }
