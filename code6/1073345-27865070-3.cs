    using (Context ctx = new Context())
    {
        var person = ctx.Persons.Single(x => x.Id == <personid>);
        person.Account = new Account();
        ctx.SaveChanges();
    }
