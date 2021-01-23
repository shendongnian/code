    public ActionResult Details(long? id)
    {
        if (!id.HasValue)
            return new EmptyResult();
        if (!AuthorizationProvider.CanI<CourseReport>(AuthorizationProvider.Abilities.View, id.Value))
            return RedirectToAccessDenied();
            
         // etc.
    }
