    System.Web.UI.WebControls.Menu mainMenu = (System.Web.UI.WebControls.Menu)sender;
    if (!((SiteMapNode)e.Item.DataItem).Roles.Contains(Session["Role"].ToString()))
    {
        mainMenu.Items[0].ChildItems.Remove(e.Item);
    }
