    HttpCookie menuCookie = new HttpCookie("menuCookie");    
    menuCookie.Values.Add("menuAppearance", schedule.MinimisedMenuBool);
    menuCookie.Expires = DateTime.Now.AddYears(1);
    
    Response.Cookies.Add(menuCookie);
