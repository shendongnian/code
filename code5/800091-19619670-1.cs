    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ForumPostControl myControl = (ForumPostControl)e.Item.FindControl("ForumPostControl1");
            myControl.MyProperty = 20;//My custom property of user control
        }
    }
