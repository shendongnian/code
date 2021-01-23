    private void element_MouseEnter(object sender, MouseEventArgs e) 
    {            
        timer.Start();
        element.Unloaded += OnElementUnloaded;
    }
    
    private void OnElementUnloaded(object sender, EventArgs e)
    {
        element.Unloaded -= OnElementUnloaded;
        timer.Stop();
    }
    private void dt_Tick(object sender, EventArgs e) 
    {
        element.Unloaded -= OnElementUnloaded;
       //Some functionality
    }
