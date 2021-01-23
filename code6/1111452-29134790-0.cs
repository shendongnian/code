    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Appointment appointment)
    {
        //This action will receive a "Model" (the appointment object) from the View (WebPage).
        //Most "HttpPost" methods are attempting to Save data in some way: Update, Create, etc. 
        //The general flow in an MVC Post method is
        //1. Check that the Model is Valid (required fields have a value, numbers don't have letters, etc.)
        //2. Then perform any server side checks (like conflicting schedules)
        //3. Then attempt to save.
        //4. If successful, return to Index. Else, add the Error to the Model and return the Model.
        try{
            //Use LINQ to check if the Appointment the User wants to book
            // 1. Starts before any other appointment ends 
            // 2. AND ALSO Ends after any other appointment starts.
            // If both conditions are true, there is some overlap
            // Making a guess as to what the fields representing Start and Stop times are called.
            // Replace the field names as appropriate
            if (db.Appointment.Where(a => a.EndTime > appointment.StartTime && a.StartTime < appointment.EndTime).Any()) 
                //If any existing appointment exists, then add a model state error.
                ModelState.AddModelError("StartTime", "Time not available.");
            //Using the Logged In User's UserName as the appointment's UserName
            appointment.username = User.Identity.Name;
            
            //TODO: Add in any other checks or changes here.
            //Example: Check if the appointment is within business hours.
            //They will follow the same format:
            //   Check the Condition
            //   If something is wrong, add the ModelError to the ModelState.
            //If a field is invalid, or we added a ModelError, the ModelState will NOT be valid.
            if (ModelState.IsValid)
            {
                //Add a row to the appointment table.
                db.Appointment.Add(appointment);
                //Save the change.
                db.SaveChanges();
                //Send the user back to Index.
                return RedirectToAction("Index", "Appointment");
            }
        }
        catch (Exception ex)
        {
            //Returns a detailed error message to the User.
            //While helpful for development, this is generally a no-no in production.
            return View(ex.ToString());
        }
        //Return the appointment model back to the View.
        //The model will contain the ModelError, which will trigger
        // any validation code on the View.
        return View(appointment);
    }
