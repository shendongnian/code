        protected void MenuExamGen_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            System.Web.UI.WebControls.Menu menu = (System.Web.UI.WebControls.Menu)sender;
            SiteMapNode node = (SiteMapNode)e.Item.DataItem;
            if (!((SiteMapNode)e.Item.DataItem).Roles.Contains(Session["Role"].ToString()))
            {
                menu.Items.Remove(e.Item);
            }
        }
