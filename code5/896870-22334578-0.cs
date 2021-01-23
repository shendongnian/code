    public ActionResult Login(HrpUser loginModel)
    {
        if (loginModel.username == "yourname" && loginModel.password == "yourpassword")
        {
            SetHrpLogonAccepted();
            // Load Hrp object here, then show the main Hrp page
            return RedirectToAction("Index", hrp);
        }
        else
        {
            return View("Login");
        }
    }
