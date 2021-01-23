    if (ModelState.IsValid)
    {
                bug.User = currentUser;
                //Retrieve the project from the database
                var projectRecord = db.Projects.FirstOrDefault(p=>p.ProjectID == id);
                bug.Projects = projectRecord;
                db.Bugs.Add(bug);
                db.SaveChanges();
                return RedirectToAction("Index");
    }
