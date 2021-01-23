    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lbl = (Label)e.Item.FindControl("Label1");
            LinkButton link = (LinkButton)e.Item.FindControl("LinkButton1");
            RadioButton rdbtn = (RadioButton)e.Item.FindControl("control_id");
        }
    }
