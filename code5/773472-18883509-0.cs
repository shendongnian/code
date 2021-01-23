    public ActionResult SendEmail(MyModel model) {
        Mailer.EmailAdmin(this, model);
        Mailer.EmailUser(this, model);
        MyOtherModel otherModel = new MyOtherModel();
        otherModel.Message = "Your request has been forwarded to the appropriate administrator." 
        + " \n You will be notified when the application has been processed.";
        return View("MyView", otherModel);
    }
