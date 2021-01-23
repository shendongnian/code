    foreach (Menu menuBE in lstMenus){
        if (menuBE.Parameters.Length > 0){
           dynamic menu = new{
               menuBE.MenuID,
               menuBE.ParentMenuID,
               menuBE.LinkText,
               menuBE.ScreenName,
               menuBE.Parameters,
               menuBE.URL
           };
        }
        else {
           dynamic menu = new{
               menuBE.MenuID,
               menuBE.ParentMenuID,
               menuBE.LinkText,
               menuBE.ScreenName,
               menuBE.URL
           };
        }
        menus.Add(menu);
    }
