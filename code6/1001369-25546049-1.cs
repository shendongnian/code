    if (ModelState.IsValid)
    {
                bug.User = currentUser;
                //Set the project ID directly(i'm assuming you have a projectID property)
                bug.Projects_ProjectID = id;
                db.Bugs.Add(bug);
                db.SaveChanges();
                return RedirectToAction("Index");
    }
