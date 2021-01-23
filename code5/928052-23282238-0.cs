    public ActionResult Index()
    {
        var model =
            new UsersIndex
            {
                Users = GetUsers()
            };
       return View(model);
    }
    private IEnumerable<User> GetUsers()
    {
        using(var context = new CustomContext())
        {
            return context.Users.ToList();
        }
    }
