    [HttpPost]
    public ActionResult NewPlaces(EnrolleePlaces dd) // any name other than "places"
    {
           if (ModelState.IsValid)
           {
               repo.SaveEnrolleePlaces(places);
               return RedirectToAction("Settings");
           }
           return View("EditPlaces", places);
    }
