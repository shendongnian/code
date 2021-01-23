    private int m_editIndex = -1;
    protected void rItems_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edit":
                m_editIndex = e.Item.ItemIndex;
                break;
            ... // Cancel, Update, Delete, etc
            case "Cancel":
                m_editIndex = -1;
                break;
        }
        BindItemsDataSource();
    }
    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool edit = e.Item.ItemIndex == m_editIndex;
            HtmlGenericControl tbody = e.Item.FindControl("itemRows") as HtmlGenericControl;
            tbody.Visible = !edit;
            tbody = e.Item.FindControl("editItemRows") as HtmlGenericControl;
            tbody.Visible = edit;
            if (edit)
            {
                PopulateEditableFieldValues(e.Item);
            }
        }
    }
