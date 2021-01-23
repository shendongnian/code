    protected void gridview1_RowCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
           string strId = gridview1.DataKeys[e.Item.ItemIndex].ToString();
        }
    }
