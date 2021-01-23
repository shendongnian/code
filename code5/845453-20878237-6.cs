    public ActionResult Index()
    {
        var model = new User
        {
            Name = "Test",
            Groups = new List<Group>
            {
                new Group {Name = "GROUP1"},
                new Group {Name = "GROUP2"}
            }
        };
        return View(model);
    }
