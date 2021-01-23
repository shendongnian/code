    public IEnumerable<Person> GetPersons()
    {
        using (var ctx = new ProductContext())
        {
            return ctx.Person;
        }
    }
