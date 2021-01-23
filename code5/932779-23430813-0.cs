    if (!Page.IsPostBack)
    {
        ClientDD.DataBind();
        // really not sure what you're doing here.
        // if this isn't a post-back then there wouldn't *be* a selected value...
        ClientDD.Items.FindByValue(ClientDD.SelectedValue).Selected = true;
        ClientDD.SelectedItem.Selected = true;
        // select based on the query string
        var selectedValue = Request.QueryString["foil"];
        if (!string.IsNullOrEmpty(selectedValue))
            CliendDD.Items.FindByValue(selectedValue).Selected = true;
    }
