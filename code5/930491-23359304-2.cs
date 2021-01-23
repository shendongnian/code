    protected void rprSSNested_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            if (e.CommandName == "cmd")
            {
                string ss = ((TextBox)e.Item.FindControl("textbox")).Text;
                Response.Write(ss);
            }
        }
    }
