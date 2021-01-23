    public void Update(Foo foo)
    {
        var existing = _myDb.Find(foo.Id);
        foreach(Bar bar in existing.Bars.ToList()) 
        {
            _myDb.Remove(bar);
        }
        existing.Bars.Clear();
        foreach(Bar bar in foo.Bars)
        {
            existing.Bars.Add(bar);
        }
        // map other properties...
        _myDb.SaveChanges();
    }
