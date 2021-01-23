        public ActionResult Delete(int id)
        {
            //Find the person in the DB.  Use the supplied "id" integer as a reference.
            Person somePerson = db.People
                .Where(p => p.Id == id)     //this line says to find the person whose ID matches our parameter
                .FirstOrDefault();          //FirstOrDefault() returns either a singluar Person object or NULL
            if (ModelState.IsValid)
            {
                db.People.Remove(somePerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(somePerson);
        }
