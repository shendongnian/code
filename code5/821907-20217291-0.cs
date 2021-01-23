    public ActionResult_LoginPartial(LoginModel login) {
            try {
                var system = (from u in db.RegisterLedgers
                              where u.EmailID == login.EmailID && u.RegisteredPassword == login.PaSsWoRd
                              select u).FirstOrDefault();
                if (system != null) {
                    Session["LoggedInUser"] = system;
                    FormsAuthentication.SetAuthCookie(system.RegisteredName, false);
                 return Json(data = result, message = "suceed" JsonRequestBehavior.AllowGet);
                }
              return Json(data=null, message = "system is null" JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                ModelState.AddModelError("", ex);
                return Json(data=null, message = "exception" JsonRequestBehavior.AllowGet);
            }
        }
