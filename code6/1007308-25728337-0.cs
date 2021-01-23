    if (ModelState.IsValid)
        {
            var userfromDb = db.Users.Find(loggedUser.EmployeeId);
            userfromDb .Email = user.Email;//etc...
            db.SaveChanges();
            return RedirectToAction("Index");
        }
