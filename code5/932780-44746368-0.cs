    if (!Page.IsPostBack)
        {
            ClientDD.DataBind();
            var index = ClientDD.Items.IndexOf(ClientDD.Items.FindByValue(ClientDD.SelectedValue));
            ClientDD.SelectedItem = index;
            
            // select based on the query string
            selectedValue = Request.QueryString["foil"];
            if (!string.IsNullOrEmpty(selectedValue))
                var index = ClientDD.Items.IndexOf(ClientDD.Items.CliendDD.Items.FindByValue(selectedValue));
            ClientDD.SelectedItem = index;
    }
    
