    public void Register(User user)
    {
        if (!ModelState.IsValid)
            return View("Index");
        UserContext userContext = new UserContext();
        userContext.users.Add(user);
        userContext.SaveChanges();
        return RedirectToAction("ShowUsers")
    }
