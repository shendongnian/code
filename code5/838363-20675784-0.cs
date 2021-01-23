    [HttpPost]
        public ActionResult GetPassword(YourModel yourmodel)
        {
            ViewModel model = new ViewModel();
    
            model.VerifyUserExists(yourmodel.EmailForgotPassword);
            return View(model);
        }
