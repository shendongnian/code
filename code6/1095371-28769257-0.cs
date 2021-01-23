    public static Person Add(Person person)
    {
        using (var db = new DBDataContext())
        {
            db.Person.InsertOnSubmit(person);
            db.SubmitChanges();
            return person;
        }
    }
