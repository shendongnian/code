    using (PersonContext db = new PersonContext())
    {
        Person person = db.Persons.Where(t => t.Name == "My Name").FirstOrDefault<Person>();
        db.Persons.Remove(person);
        db.SaveChanges();
    }
