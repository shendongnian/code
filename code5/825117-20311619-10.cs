    public ActionResult Index()
    {
            var model = new List<User> { new User { Id = 1, Name = "name", 
            Friends = new List<Friend> { new Friend { Id = 1, UserName = "name", ImageUrl = "a.jpg" } }, 
            new User { Id = 2 Name = "name2",  
            Friends = new List<Friend> { new Friend { Id = 1, UserName = "name", ImageUrl = "b.jpg" } }
                };
                return View(model);
        }
