    public ActionResult EditAdmin(int UserId)
    { 
            User user = persons.Users.Find(id);
            return View(new UserViewModel { Name = user.Name, Sex = user.Sex });
    }
    [HttpPost]
    public ActionResult EditAdmin(UserViewModel user)
    { 
            var dbUser = persons.Users.Find(id);
            dbUser.Name = user.Name;
            dbUser.Sex = user.Sex;
            persons.Entry(dbUser).State = EntityState.Modified;
            persons.SaveChanges();
    }
