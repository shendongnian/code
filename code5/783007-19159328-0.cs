    public void FillMenu(EntityCollection menuList, List<Menu> hList, int? parentMenuId)
        {
            var g = from m in menuList
                    where ((MenuEntity)m).ParentMenuId == parentMenuId
                    select (MenuEntity)m;
            foreach (MenuEntity menu in g)
            {
                var newMenu = new Menu();
                newMenu.Id = menu.Id;
                newMenu.Name = menu.Name;
                newMenu.ChildMenu = new List<Menu>();
                FillMenu(menuList, newMenu.ChildMenu, newMenu.Id);
                hList.Add(newMenu);
            }
        }
