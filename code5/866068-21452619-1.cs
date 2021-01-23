    [AllowAnonymous]
        public JsonResult ValidateUser()
        {
            String Uid = Request.QueryString["id"];
            String Pass = Request.QueryString["pass"];
            String username = Uid;
            String password = Pass;
            if (Membership.ValidateUser(username, password))
            {
                //Session["username"] = username;
                FormsAuthentication.RedirectFromLoginPage(username, true);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("falied", JsonRequestBehavior.AllowGet);
            }
        }
