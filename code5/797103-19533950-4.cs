    protected void Page_Load(object sender, System.EventArgs e)
    {
         btn_submit.Click += btn_submit_click;
         btn_submit.OnClientClick = @"return getConfirmationValue();";
    }
    protected void btn_submit_click(object sender, ImageClickEventArgs e)
    {
      
                        bool type = false;   
       if(hfWasConfirmed.Value == "true")
     {
        //If clicks OK button
      }
     else
    {//If clicks CANCEL button
    }
    } 
