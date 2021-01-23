    [HttpPost]
    public ActionResult AddUser(UserCreateViewModel user)
    {
        ModelState.Clear(); // <-------
        if (ModelState.IsValid)
        {
            var success = UserRepository.AddUser(user);
            if (success)
            {
                return View("Success");
            }
        }
        return View("AddUser");
    }
