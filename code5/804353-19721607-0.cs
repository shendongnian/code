     int count = 0;
            foreach (RadioButton rb in divContainer.Controls.OfType<System.Web.UI.WebControls.RadioButton>())
            {
                if(rb.GroupName=="a")
                {
                    count++;
                }
            }
