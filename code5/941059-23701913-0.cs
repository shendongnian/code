    public void PartiallyChangeEntityConstraint()
    {
        var nmToModify = new NameMap()
        {
            Id = 2,
            MainLang = String.Empty,
            TitleMap = new TitleMap { Id = XXX }
        };
        _context.NameMaps.Attach(nmToModify);
        var title = new TitleMap { Id = 3 }
        _context.TitleMaps.Attach(title);
        _context.Entry(nmToModify).Reference(a => a.TitleMap).CurrentValue = title;
        // You could also simply use here: nmToModify.TitleMap = title;
        // or did you disable automatic change detection?
        _context.SaveChanges();
    }
