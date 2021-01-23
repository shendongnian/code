    private void ChangeObject(object obj)
    {
        if (something)
            obj.Name = "New name";
    }
    using (var db = new Context())
    {
        var obj = db.Objects.First();
        ChangeObject(obj);
        db.SaveChanges();
    }
