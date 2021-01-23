     [HttpPost]
        public ActionResult Create(SystemUser users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ss.StudentsTbls.AddObject(student); // Ignore this
                    ss.SystemUsers.Add(users);
                    ss.SaveChanges();
                    return RedirectToAction("AdminIndex");
                }        
            }
            catch (Exception exception)
            {
            }
            return View(users);
        }   
    
