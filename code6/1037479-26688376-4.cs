    public ActionResult Index(int id)
    {
        var user = Container.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }
