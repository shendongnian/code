    protected void Repeater1_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GenericDataBound<SpecialClass>(sender, e);  // here you know the type
        }
    }
