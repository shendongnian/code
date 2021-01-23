    using (PersonContext db = new PersonContext())
    {
        List<Person> persons = db.Persons.Where(t => t.Name == "My Name").ToList();
        db.Persons.RemoveRange(persons);
        db.SaveChanges();
    }
