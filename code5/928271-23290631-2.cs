    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Remove Names dropdownlist items 
                ddlNames.Items.Clear();
                string strClass = string.Empty;
                ComboBox comboBox = (ComboBox) sender;
		strClass= (string) ddlClass.SelectedItem;
                List<string> list = null;
    
                // Bind Names dropdownlist based on Class value 
                list = GetNamesByClass(strClass);
                ddlNames.DataSource = list;
               
    
    
            }
    
            private List<string> GetNamesByClass(string clsss)
            {
                //Your database code to get names list based on class goes here
                //have to write code to get 2nd dropdown data here
                //You can use your existing code for 1st dropdown 
            }
