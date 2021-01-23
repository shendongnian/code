     protected void dd1_SelectedIndexChanged1(object sender, EventArgs e)
            {
                multiview.ActiveViewIndex = -1;
                if (dd1.SelectedValue == "1")
                {
                    multiview.ActiveViewIndex = 0;
                }
    
            }
