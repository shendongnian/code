    using (var transaction = context.Database.BeginTransaction())
    {
        var myThing = new ReferenceThing
        {
            Id = 1,
            Name = "Thing with Id 1"
        };
        context.Set<ReferenceThing>.Add(myThing);
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing ON");
        context.SaveChanges();
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing OFF");
        transaction.Commit();
    }
