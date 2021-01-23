    if (User.IsInRole("RegularUser"))
    {
        var user = UserManager.FindById(User.Identity.GetUserId());
        if (!user.PersonsPermittedToView.Any(pptv => 
                  pptv.CustomerToVisit.PersonToVisit.Id == person.Id))
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
