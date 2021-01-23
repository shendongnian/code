    //at first assign event handlers
    button1.Click += new EventHandler(Button_Click);
    button2.Click += new EventHandler(Button_Click);
    
    
    //single event handler
    private void Button_Click(object sender, System.EventArgs e) 
    {
        // Add event handler code here.
        Debug.WriteLine("You clicked: {0}", sender);
    }
