    try
    {
        if (ModelState.IsValid)
        {
            ss.SystemUsers.Add(users);
            ss.SaveChanges();
            return RedirectToAction("AdminIndex");
        }
        return View(users);
    }
    catch (DbEntityValidationException ex)
    {
        var errorMessages = ex.EntityValidationErrors
                .SelectMany(e => e.ValidationErrors)
                .Select(e => e.ErrorMessage)
                .ToList();
        // Here you can see the actual validation errors when you're debugging
    }
