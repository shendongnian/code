    [HttpPost]
    public ActionResult AddAttendantToEvent(int users  , int EventID )
    {
        if (ModelState.IsValid)
        {
            // this should be a using statement once you implement IDisposable
            // e.g. using( var uow = new RsvpUnitOfWork() ) { ... }
            var uow = new RsvpUnitOfWork();
            // you need to validate that user != null
            var user = uow.UserRepo.Find(users);
            // possible null reference exception if dinner event not found for EventID
            uow.DinnerEventRepo.Find(EventID).Attendants.Add(user); //Add the User to the Event.
            uow.Save();
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
