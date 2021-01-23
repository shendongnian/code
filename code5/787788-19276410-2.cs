    var model = new MyModel() { Id = id, OtherData = data };
    using (var db = new MyEfContextName())
    {
        db.MyModels.Attach(model);
        db.Entry(model).Property(x => x.OtherData).IsModified = true;
        db.SaveChanges();
    }
