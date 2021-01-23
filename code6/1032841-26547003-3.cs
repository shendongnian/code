    public ActionResult EditAdmin(int userId)
    { 
            User user = persons.Users.Find(userId);
            return View(new UserViewModel 
                { 
                    Id = user.Id,
                    Name = user.Name, 
                    Sex = user.Sex 
                });
    }
    [HttpPost]
    public ActionResult EditAdmin(UserViewModel user)
    { 
            var dbUser = persons.Users.Find(user.Id);
            dbUser.Name = user.Name;
            dbUser.Sex = user.Sex;
            persons.Entry(dbUser).State = EntityState.Modified;
            persons.SaveChanges();
    }
