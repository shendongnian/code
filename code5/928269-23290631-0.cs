    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Remove Names dropdownlist items 
                ddlNames.Items.Clear();
                string strClass = string.Empty;
                strClass = ddlClass.SelectedValue;
                List<string> list = null;
    
                // Bind Names dropdownlist based on Class value 
                list = GetRegionByCountry(strClass);
                ddlNames.DataSource = list;
                ddlNames.DataBind();
    
    
            }
    
            private List<string> GetRegionByCountry(string clsss)
            {
                //Your database code to get names list goes here
            }
