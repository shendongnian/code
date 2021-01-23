        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(OSModel os)
        {    
            if (ModelState.IsValid)
            {
                 
                _db.Entry(os).State = EntityState.Modified;
                _db.SaveChanges();// you must add this line
                // success !
                string str = "o";
                return RedirectToAction("Index", new { str = str });
            }
            // fail !
            return View(os);
        }
