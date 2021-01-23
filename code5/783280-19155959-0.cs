    if (e.CommandName == "ARCHIEVE")
        {
            LinkButton lnkButton = (LinkButton)e.CommandSource;
            if (lnkButton != null)
               
                if (lnkButton.Text.ToUpper() == "ARCHIEVE")
                {
                   
                    lnkButton.Text = "VIEWED";
                }
             
                else if (lnkButton.Text.ToUpper() == "VIEWED")
                {
            
                    lnkButton.Text = "ARCHIEVE";
                }
        }
