        public void HideOrShowMenuItems(bool UserIsLoggedIn)
        {
            List<ContextMenuStrip> menuList = new List<ContextMenuStrip>(); //Your menus go here
            foreach (ContextMenuStrip menu in menuList)
            {
                foreach (MyMenuItem menuItem in menu.Items)
                {
                    if (UserIsLoggedIn || menuItem.ShowWhenNotLoggedIn)
                        menuItem.Visible = true;
                    else
                        menuItem.Visible = false;
                }
            }
        }
