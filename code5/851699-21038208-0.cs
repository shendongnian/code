    public Task<RedirectToRouteResult> UpdateUser(ProfileModel model)
    {
      return Task.Factory.StartNew(showMethod).ContinueWith(
        t => {
          return RedirectToAction("ViewUser","UserProfile");
      });
    }
