                menu = new ContextMenu();
                mnudel = new MenuItem("Delete");
                mnuresize = new MenuItem("Resize");
                menu.MenuItems.AddRange(new MenuItem[] { mnudel, mnuresize });
                   submenu1 = new MenuItem("Sub1");
                submenu2 = new MenuItem("Sub2");
                mnuresize.MenuItems.AddRange(new MenuItem[] { submenu1, submenu2 })
