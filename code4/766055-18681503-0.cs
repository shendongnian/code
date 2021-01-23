    private void GetControl( ControlCollection controls )
    {
      foreach (Control ctrl in controls)
    {
         if(ctrl.ID == "a1")
        {
           seatButton = (Button)ctrl;
        }
       
         if( ctrl.Controls != null)
         // call recursively this method to search nested control for the button 
         GetControl(ctrl.Controls);    
    }
    }
