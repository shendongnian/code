    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        SiteMapNode node = (SiteMapNode)e.Item.DataItem;
        if (node["HideFromMenu"] == "true")
        {
            if (e.Item.Parent != null) //if this item has a parent..
                e.Item.Parent.ChildItems.Remove(e.Item); //use parent to remove child..
            else
                Menu1.Items.Remove(e.Item); //else.. remove from menu itself.
        }
    }
