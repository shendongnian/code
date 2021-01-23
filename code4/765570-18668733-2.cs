    using (DataContext db = new DataLayer.DataContext())
    {
        var tasks = db.Groups.ToList().Select(i => GetAdminsFromGroupAsync(i.Gid));
        var results = await Task.WhenAll(tasks);
    }
