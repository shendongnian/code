    public ActionResult Edit(int id)
    {
       Account account = db.Accounts.Find(id);
       if (account == null)
       {
          return HttpNotFound();
       }
       ViewBag.Roles = RoleDropDownList(account.URole); // Assuming RoleDropDownList returns a SelectList
       return View(account);
    }
