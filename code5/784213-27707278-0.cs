    public ActionResult Login(LoginModel model)
            {
                if(model.UserName=="xyz" && model.Password=="xyz")
                {
                    Session["uname"] = model.UserName;
                    Session.Timeout = 10;
                    return RedirectToAction("Index");
                }
    }
