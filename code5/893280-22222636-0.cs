        //
        // GET: /Movies/
        public ActionResult AddStudent()
        {
            return View();
        }
         //
        // POST: /Movies/
        [Post]
        public ActionResult AddStudent(MovieModel model)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(model);
                db.SaveChanges();
            }
            return View(model);
        }
