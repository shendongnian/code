        protected void MenuExamGen_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (!((SiteMapNode)e.Item.DataItem).Roles.Contains(Session["Role"].ToString()))
            {
               e.Item.Text = "Removed";
            }
        }
