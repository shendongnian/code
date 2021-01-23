    public ActionResult My()
    {
      if (User.Identity.IsAuthenticated == false)
      {
        return new HttpUnauthorizedResult();
      }
      // ... other code ...
    }
