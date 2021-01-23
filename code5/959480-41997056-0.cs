    using (var transaction = context.Database.BeginTransaction())
    {
        var item = new ReferenceThing{Id = 418, Name = "Abrahadabra" };
        context.IdentityItems.Add(item);
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
        context.SaveChanges();
        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[User] OFF");
        transaction.Commit();
    }
