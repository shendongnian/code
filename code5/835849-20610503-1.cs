    protected void rptFoo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            FooType obj = (FooType)e.Item.DataItem;
            Repeater rptBar = (Repeater)e.Item.FindControl("rptBar");
            if(obj.Children.Count() > 0)
            {
                rptBar.DataSource = obj.Children;
                rptBar.DataBind();
            }
            else
            {
                rptBar.Visible = false;
            }
        }
    }
