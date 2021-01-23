        public ICollection<MenuItem> GetMenuItemsAsTreeList()
        {
            AllMenuItems = (from e in entityContext.MenuItemSet select e).ToList();
            Dictionary<int, MenuItem> dic = AllMenuItems.ToDictionary(n => n.Id, n => n);
            List<MenuItem> rootMenuItems = new List<MenuItem>();
            foreach (MenuItem menuItem in AllMenuItems)
            {
                if (menuItem.ParentMenuItemId.HasValue)
                {
                    MenuItem parent = dic[menuItem.ParentMenuItemId.Value];
                    menuItem.ParentMenuItem = parent;
                    parent.SubMenuItems.Add(menuItem);
                }
                else
                {
                    rootMenuItems.Add(menuItem);
                }
            }
            return rootMenuItems;
        }
