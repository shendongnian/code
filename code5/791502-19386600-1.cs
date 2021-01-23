    var result = context.User
       .Where(u => u.Id == userId)
       .Select(u => new {
           Addresses = u.UserAddresses.Select(ua => ua.Address)
                .Where(a => a.Enabled),
           User = u // if you need this as well 
       })
       .Single();
