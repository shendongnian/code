     protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if(PopupOpen== True)
            { 
              ppChangePIN.IsOpen=false;
    
             PopupOpen=False;
             e.Cancel = true;
            }
            else
            {}
        }
