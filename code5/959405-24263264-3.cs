    public ActionResult Index(string url)
        { 
            getCredentials();
            if (Authenticate(userName, password))
            {
              return View(); 
            }
            else
            {
              TempData["ErrorMessage"]="Wrong Credential";
              return Redirect(url);
            } 
           }
        }
