    public UserWithOtherStuffModel GetUserById(int sessionId)
    {
        using(db)
        {
            var user = (from u in db.Users 
                where u.Id == sessionId 
                select new UserWithOtherStuffModel{
                    Id = u.Id,
                    Name = u.Name,
                    OtherStuff = u.MyOtherTable.SomeColumn
                }).SingleOrDefault();
            return user;
        }
    }
