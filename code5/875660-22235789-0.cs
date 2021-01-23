    [Authorize]
    public ActionResult Profile()
    {
      string userName = this.User.Identity.Name;
      var users = _service.Get().Where(x => x.EmailAddress.ToLower() == userName );
      var user = users.First();
      return View(user);
    }
