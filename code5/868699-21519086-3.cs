    public ActionResult Index()
    {
        var qry = from q in db.SystemUsers
                  select new SystemUsersIndexViewModel
                  {
                      UserName = q.Username,
                      Password = q.Password,
                      FirstName = q.FirstName,
                      LastName = q.LastName,
                      MiddleName = q.MiddleName
                  };
        return View(qry);
    }
