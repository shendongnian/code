    public static void Update(string name, string family)
    {
        using (var newContext = new MyDbContext())
        {
            // get all Persons with FirstName equals name
            var personsToUpdate = newContext.Persons.Where(o => o.FirstName == name);
            // update LastName for all Persons in personsToUpdate
            foreach (Person p in personsToUpdate)
            {
                p.LastName = family;
            }
            newContext.SaveChanges();
        }
    }
