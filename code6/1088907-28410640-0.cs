    public ActionResult MyMethod(model MyModel)
    {
        if (ModelState.IsValid)
        {
             // normal processing
        }
        else
        {
            if (ModelState["Username"].Errors.Count > 0)
            {
                var msg = ModelState["Username"].Errors[0].ErrorMessage;
            }
        }
    }
