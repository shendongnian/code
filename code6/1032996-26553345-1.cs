    // Default Licenses - create
    var licenses = new[]{
        new License { DateCreated = DateTime.Now.AddDays(-3), CustomerId = customers[0].CustomerId },
        new License { DateCreated = DateTime.Now.AddDays(-2), CustomerId = customers[1].CustomerId },
        new License { DateCreated = DateTime.Now.AddDays(-1), CustomerId = customers[2].CustomerId }
    };
    context.Licenses.AddOrUpdatE(r => r.DateCreated, licenses[0], licenses[1], licenses[2]);
    
