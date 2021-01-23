    // replace "EFDbContext" with your EF context class
    using (var context = new EFDbContext()) 
    {
        // replace "Id" with your primary key column name for tender
        var currentTender = context.Tenders.Single(t => t.Id == tenderId);
        currentTender.ViewCount = currentTender.ViewCount + 1;
        context.SaveChanges(); 
    }
