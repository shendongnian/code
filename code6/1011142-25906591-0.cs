    using( var block1 = NinjectKernelReference.BeginBlock())
    using( var block2 = NinjectKernelReference.BeginBlock())
    {
        var context1 = block1.Get<MyContext>(); 
        var context2 = block2.Get<MyContext>(); 
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
    }
