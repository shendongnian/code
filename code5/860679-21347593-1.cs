     protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
                try
                {
                    if (ddl1.SelectedValue == "1")
                {
                    ddl2.Enabled = false;
                    //ddl2.Visible = false;
                }
                else
                {
                    ddl2.Enabled = true;
                    //ddl2.Visible = true;
                }
                }
                catch (Exception ex)
                {
                   string b=  ex.Message;
                }
    
        }
