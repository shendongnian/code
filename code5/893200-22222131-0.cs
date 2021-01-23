    [Authorize(Roles = "Admin")]
    public ActionResult Index()
    {
        var Db = new ApplicationDbContext();
        var users = Db.Users;
        //ViewModel will be posted at the end of the answer
        var model = new List<EditUserViewModel>();
        foreach(var user in users)
        {
            var u = new EditUserViewModel(user);
            model.Add(u);
        }
        return View(model);
    }
