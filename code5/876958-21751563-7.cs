    public ActionResult Attendee()
    {
        //You can pass null as the view model and the view/editor template won't break
        return View();
        //This would also work, showing that you can have a nullable with null value
        //return View(new AttendeeResponse());
        //If the nullable enum has a value, it would appear as selected:
        //return View(new AttendeeResponse{Isattending = IsAttending.NotAttending});
    }
