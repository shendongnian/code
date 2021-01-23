    Entity instance;
    using(var scope = new TransactionScope())
    {
        instance = db.Entities.FirstOrDefault(e => e.Status == "Pending");
        instance.Status = "Processing";
        db.SaveChanges();
        scope.Complete();
    }
