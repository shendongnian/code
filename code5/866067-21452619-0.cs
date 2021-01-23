    [AllowAnonymous]
        public JsonResult RegisterUser()
        {
            String Uid = Request.QueryString["id"];
            String Pass = Request.QueryString["pass"];
            String username = Uid;
            String password = Pass;
            try
            {
                //Session["username"] = username;
                Membership.CreateUser(Uid, Pass);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json("falied", JsonRequestBehavior.AllowGet);
            }
        }
