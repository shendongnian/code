        private void BindDropDownList()
    {
        // Declare a Dictionary to hold all the Options with Value and Text.
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add("-1", "Select Option");
        options.Add("1", "Option 1");
        options.Add("2", "Option 2");
        options.Add("3", "Option 3");
        options.Add("4", "Option 4");
        options.Add("5", "Option 5");
    
        // Bind the Dictionary to the DropDownList.
        ddlDropDownId.DataSource = options;
        ddlDropDownId.DataTextField = "value";
        ddlDropDownId.DataValueField = "key";
        ddlDropDownId.DataBind();
    }
