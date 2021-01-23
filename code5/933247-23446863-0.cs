    context.Configuration.AutoDetectChangesEnabled = false;
    foreach (var contact in contacts)
    {
        context.Entry(contact).Collection(c => c.Addresses).Load();
        Console.WriteLine(contact.Addresses.Count());
    }
