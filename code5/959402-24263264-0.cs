    public ActionResult Index(string ErrorMessage)
        {
            if(!string.isNullOrEmpty(ErrorMessage))
              ViewBag.ErrorMessage=ErrorMessage;
            getCredentials();
            if (Authenticate(userName, password))
                return View();
            else{
                ErrorMessage ="Wrong Credential";
                return View(errorMessage);  
            }
        }
