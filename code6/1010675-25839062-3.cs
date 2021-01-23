    [HttpPost]
    public ActionResult CreateQuestions(RegistrationViewModel vm)
    {
      if (!ModelState.IsValid)
      {
        // You need to rebuild the question text and possible answers because these are not posted back
        return View(vm);
      }
      // Your model is now populated with the ID of each question and the selected answer which can be saved to the database
