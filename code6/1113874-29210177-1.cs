    var instance = db.Entities.FirstOrDefault(e => e.Status == "Pending");
    instance.Status = "Processing";
    // Save changes so the other clients can see that this row is locked
    db.SaveChanges();
    // Perform custom logic
    // And mark the instance as finished
    db.Table<Entity>().Attach(instance);
    instance.Status = "Finished";
    db.SaveChanges();
