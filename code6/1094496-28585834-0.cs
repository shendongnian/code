    using EntityFramework.Extensions;
    ...
    int[] myIds = { 592, 593, 594 };
    
    using (var context = _dataContextFactory.GetContext())
    {
        // Define a filter expression to retrieve matching items
        var filter = context.MyTables.Where(item => myIds.Contains(item.Id));
        // Update the StatusId of matched items
        context.MyTables.Update(filter, i => new Item { StatusId = 3 });
        context.SaveChanges();
    }
