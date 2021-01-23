    public ActionResult SendMail(string login)
    {
       this.Model = login; // set the model
       return View("ValidateLogin"); // reponse the ValidateLogin view
    }
