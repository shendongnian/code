    var modifiedAppplicationTransactions = context.ChangeTracker.Entries<ApplicationTransactions>().Where(x => x.State == EntityState.Modified);
    foreach (var item in modifiedAppplicationTransactions )
    {
        if (item.Entity.ApplicationId == null)
        {
            context.Entry(item.Entity).State = EntityState.Deleted;
        }
    }
    context.SaveChanges():
