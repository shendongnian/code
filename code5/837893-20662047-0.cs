    [HttpPost]
    public ActionResult Process(ContactViewModel c)
    {
        if (ModelState.IsValid)
        {
            c.Contact.DateCreated = DateTime.Now;
            db.Contacts.Add(c.Contact);
            db.SaveChanges();
            return Content("Success!");
        }
        return Content("Failure");
    }
