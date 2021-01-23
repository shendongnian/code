    public ActionResult Index()
    {
        if (Membership==null){
            throw new ArgumentNullException("Membership");
        }
        var user = Membership.GetUser();
        if (user ==null){
            throw new ArgumentNullException("User");
        }
    
        var loggedInUser = user.ProviderUserKey.ToString();
        if (loggedInUser ==null){
            throw new ArgumentNullException("loggedInUser ");
        }
     
        var query = from b in db.Logs where b.Id == loggedInUser select b;
        return View(query.ToList());
    }
