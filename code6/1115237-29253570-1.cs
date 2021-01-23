    private EPlannerDatabaseEntities db = new EPlannerDatabaseEntities();
    //
    // GET: /LoggedIn/
    public ActionResult Index(String email)
    {
      var x = from m in db.Users
              where String.IsNullOrEmpty(email) || m.Email.Contains(email)
              join up in db.UserPreferences 
              on m.Id equals up.UserId
              select up;
      return View(x);
    }
