    using (Context ctx = new Context())
    {
        var person = ctx.Persons.Single(x => x.Id == <personid>);
        person.Account = new Account();
        ctx.SaveChanges();
    }
This will throw a System.Date.Core.Entity.UpdateException as it attempts to add another entry to the Accounts table with a primary key set to &lt;personid&gt;. 
