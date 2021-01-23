      foreach (Menu menuBE in lstMenus)
        {
    
            dynamic menu = new
            {
    
              MenuID = menuBE.MenuID,
              ParentMenuID =  menuBE.ParentMenuID,
              LinkText =  menuBE.LinkText,
              ScreenName = menuBE.ScreenName,
                
              URL = menuBE.URL,
                Parameters = (menuBE.Parameters.Length>0) ? menuBE.Parameters : null
            };
            menus.Add(menu);
        }
  
