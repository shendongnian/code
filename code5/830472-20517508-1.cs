        using (var context = new MyContext())
        {
            Menu menuItem1 = new Menu();
            menuItem1.Name = "modelName";
            menuItem1.Description = "modelDescription";
            SubMenu subMenu1 = new SubMenu();
            subMenu1.Name = "subName1";
            menuItem1.SubMenus.Add(subMenu1); // how to define sum-menus (SubMenus is not null anymore)
            context.Menus.Add(menuItem1);
            
            context.SaveChanges();
        }
