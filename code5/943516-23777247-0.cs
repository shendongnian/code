    public Wsp GetFullWsp(Guid id)
    {
        var wsp = wspCollection.AsQueryable().FirstOrDefault(w => w.WspId == id);
        var sits = sitCollection.AsQueryable().Where(sit => sit.WspId == id);
        wsp.SitList = new List<Sit>(sits);
    }
