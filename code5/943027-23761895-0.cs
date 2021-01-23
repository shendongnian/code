    public void Update(User u)
        {
            var user = GetUserById(u.UserId);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
