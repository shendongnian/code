    using (var db = new DataLayer.DataContext())
    {
        Group g = new Group {
                Gid = "019282",
                Name = "Admin"
            };
            db.Groups.Add(g);
            db.SaveChanges();
    }
