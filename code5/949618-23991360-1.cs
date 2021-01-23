     private void onActivated(object sender, EventArgs e)
             {
    
                 Properties.Settings.Default.AppFocus = true;
                 
             }
    
             private void onDeactivated(object sender, EventArgs e)
             {
                 Properties.Settings.Default.AppFocus = false;
    
             }
