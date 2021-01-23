        public ActionResult SendMail(string login)
        {
            ...        
            return RedirectToAction("ResetPassword", login);
        }
        public ActionResult ResetPassword(string login)
        {
            ...
            return View("ResetPassword", login);
        }
