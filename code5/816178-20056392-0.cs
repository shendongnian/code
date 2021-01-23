    [SiteMapTitle("UserName")] 
    public ViewResult Details(int id) { 
       UserDao dao = DependencyResolver.Current.GetService<UserDao>();
    
       // This example assumes your user model object has a public property "UserName"
       var user = dao.Find(id); 
       return View(user); 
    }
