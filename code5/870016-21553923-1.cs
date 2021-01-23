    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UserViewModel viewModel) {
        var user = db.Users.Where(x => x.username == viewModel.Username).FirstOrDefault();
        user.Name = viewModel.Name;
        user.Username = viewModel.Username;
        // .. etc.
        db.SaveChanges();
    }
