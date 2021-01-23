      foreach (Menu menuBE in lstMenus)
        {
    
            dynamic menu = new
            {
    
                menuBE.MenuID,
                menuBE.ParentMenuID,
                menuBE.LinkText,
                menuBE.ScreenName,
                menuBE.Parameters,
                menuBE.URL,
                (menuBE.Parameters.Length>0) ? { MenuID = menuBE.Parameters} : null
            };
            menus.Add(menu);
        }
  
