    string userName;
    string userId;
    if (HttpContext.Current != null && HttpContext.Current.User != null 
            && HttpContext.Current.User.Identity.Name != null)
    {
        userName = HttpContext.Current.User.Identity.Name;
        userId = HttpContext.Current.User.Identity.GetUserId();
    }
