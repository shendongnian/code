    public ActionResult _LoginPartial(LoginModel login) 
    {
        try 
        {
            var system = 
                (from u in db.RegisterLedgers
                where u.EmailID == login.EmailID && u.RegisteredPassword == login.PaSsWoRd
                select u).FirstOrDefault();
    
            if (system != null) 
            {
                Session["LoggedInUser"] = system;
                FormsAuthentication.SetAuthCookie(system.RegisteredName, false);
                return Json(new { success = true; });
            }
        }
        catch (Exception ex) 
        {
            ModelState.AddModelError("", ex);
        }
    
        return Json(new { success = false; });
    }
