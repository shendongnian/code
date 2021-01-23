    InternamentosListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Table tdcamas = (Table)e.Item.FindControl("camas");
                }
    }
