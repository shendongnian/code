    [HttpPost]
    public ActionResult FirstRegistration(FirstRegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            SecondRegistrationModel secondModel = new SecondRegistrationModel();
            MapFirstToSecond(model, secondModel);
            return View("SecondRegistration", secondModel);
        }
        else
        {
            return View(model);
        }
    }
