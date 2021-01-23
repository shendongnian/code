    // At the form global level.
    System.Timers.Timer t = new System.Timers.Timer();
    
    button1.Visible = false;
    t.Elapsed += tElapsed;
    t.Interval = 1000;
    t.SynchronizingObject = this;
    t.Start();    
    
    
    
    public void tElapsed(object sender, ElapsedEventArgs e)
    {
        int BoundaryY = this.ClientSize.Height;
        // Adding the radiobutton Height to the BoundarY value keeps the radiobutton visible
        if(radioButton1.Location.Y <= (BoundaryY - b.Height))
            radioButton1.Location = new Point(radioButton1.Location.X, radioButton1.Location.Y+1);
    }
