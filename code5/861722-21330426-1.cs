    var context = new TestDbContext();
    var user = context.Users.FirstOrDefault(item => item.ID == 1);
    
    context.Addresses.Add(new Address()
    {
        City = "City",
        Street = "Street",
        Postcode = "Postcode",
        User = user
    });
    
    context.SaveChanges();
