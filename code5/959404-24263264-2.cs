    public ActionResult Index()
        { 
            getCredentials();
            if (!Authenticate(userName, password))
                 ViewBag.ErrorMessage="Wrong Credential";
            return View(); 
 
            }
        }
