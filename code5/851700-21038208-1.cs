    public Task<ActionResult> UpdateUser(ProfileModel model)
    {
      return Task.Factory.StartNew(showMethod).ContinueWith<ActionResult>(
        t => {
          return RedirectToAction("ViewUser","UserProfile");
      });
    }
