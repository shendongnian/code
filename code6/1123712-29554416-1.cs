    public ActionResult Edit(int ID)
    {
      UserVM model = new UserVM();
      // Get you User based on the ID and map properties to the view model
      // including populating the Roles and setting their IsSelect property
      // based on existing roles
      return View(model);
    }
