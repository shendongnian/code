    protected void rptrParent_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem)) {
            Repeater rptrChild = (Repeater)item.FindControl("rptrChild");
            rptrChild.DataSource = DataBinder.Eval(item.DataItem, "Group");
            rptrChild.DataBind();
        }
    }
