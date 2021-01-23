    public void Delete(User user)
    {
      using (var db = new MyDbContext)
      {
         User userToDelete = db.Users.Where(u => u.Id == user.Id).SingleOrDefault();
         if(userToDelete != null) {
           db.Rights.RemoveRange(user.Rights);
           db.Users.Remove(user);
           db.SaveChanges();
         }
      }
    }
