        public ActionResult Login(StudentLogin sl)
        {
            if (sl.Email != null)
            {
                if (ModelState.IsValid) // this is check validity
                {
                    StudentEntities1 se = new StudentEntities1();
                    var v = se.StudentLogins.Where(a => a.Email.Equals(sl.Email) && a.Password.Equals(sl.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.Id.ToString();
                        //Session["LogedUserFullname"] = v.FullName.ToString();
                        return RedirectToAction("Success", "Student");
                    }
                }
                return View(sl);
            }
            else
            {
                return View();
            }
        }
