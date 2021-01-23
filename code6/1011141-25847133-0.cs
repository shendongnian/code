    using(var context1 = IContextFactory.Create())
    using(var context2 = IContextFactory.Create())
    {
        var task1 = context1.Customers.Where(c => c.ZipCode == "4444")
                    .Select(c => new {
                                         c.Name,
                                         c.PhoneNumber
                                     })
                    .Take(50)
                    .ToArrayAsync();
        var task2 = context2.Customers.CountAsync(c => c.ZipCode == "4444");
        Task.WaitAll(task1, task2);
        return new Result { task1.Result, task2.Result };
    } // context get's disposed here
