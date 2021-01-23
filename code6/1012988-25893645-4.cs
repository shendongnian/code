    [HttpGet]
    public ActionResult Edit(string email)
    {
        // If the email the typed is find, it will display their contents on to a RsvpForm view
        return PartialView("RsvpForm", guestRepository.Find(email));
    }
