    using (DataContext db = new DataLayer.DataContext())
    {
        foreach(var i in db.Groups)
        {
            await GetAdminsFromGroup(i.Gid);
        }
    }
