    [HttpPost]
    public ActionResult AddUser(UserCreateViewModel user)
    {
        if (ModelState.IsValid)
        {
            var success = UserRepository.AddUser(user);
            if (success)
            {
                return View("Success");
            }
        }
        ModelState.Clear(); // <-------
        return View("AddUser");
    }
