    [HttpPost]
    public ActionResult YourActionMethod(FormCollection Collection)
    {
            string Country = string.Empty;
            if (Collection["txtCountry"] != null)
                Country = Collection["txtCountry"].ToString();
    //Else you can assign the values to your model object.
            return View();
    }
