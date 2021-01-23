    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl1.SelectedValue == "1")
            {
                btnSaveQ37.Enabled = true;
                btnSaveQ37.Visible = true;
    
            }
            else
            {
                btnSaveQ37.Enabled = false;
                btnSaveQ37.Visible = false;
            }
    
        }
