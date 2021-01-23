    public ActionResult validation()
        {
            var email =Request["email"];
            var pas = Request["password"];
            IQueryable<User> record=null;
            record = (db.Users.Where(x=>x.email==email));
            if (record==null)
            {
                return RedirectToAction("ReSignIn","ReSignIn");
            }
            else
            {
                return RedirectToAction("Profile","Profile");
            }
        }
