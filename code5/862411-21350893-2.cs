    public static void Update(int id, string name, string family)
    {
        var _person = new Person() { Id = id , FirstName = name, LastName = family };
    
        using (var newContext = new MyDbContext())
        {
            newContext.Persons.Attach(_person);
            newContext.Entry(_person).Property(X => X.LastName).IsModified = true;
            newContext.SaveChanges();
        }
