    public ActionResult SearchUser(string Email, int? UserId) {
                var system = from u in db.SystemUsers
                             select u;
                if (!String.IsNullOrEmpty(Email)) {
                    system = system.Where(c => c.Email.Contains(Email));
                }
    
    
                return Json(system.Where(x=>x.Email==Email),JsonRequestBehavior.AllowGet);
            }
