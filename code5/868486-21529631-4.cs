    if (IsPostBack)
    {
        //Get the index of selected tab
        if (!(ViewState["TabIndex"] == null) && (!(sender == null)))
        {
            if (sender.GetType().ToString().Equals("AjaxControlToolkit.TabContainer"))
            {
                ((AjaxControlToolkit.TabContainer)sender).ActiveTabIndex = (int)ViewState["TabIndex"];
            }
        }
    }
