        using (var context = new MyContext())
        {
            var existingMenuItem = context.Menus.Find(1);
            SubMenu newSubMenu = new SubMenu();
            newSubMenu.Name = "subName2";
            existingMenuItem.SubMenus.Add(newSubMenu); // how to define sum-menus
            context.SaveChanges();
        }
