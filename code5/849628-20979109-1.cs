    using (SepasProjectEntities sp = new SepasProjectEntities())
    {
        var query = sp.HISAccidentLocationmappings
                        .ToList()
                        .Where(p => p.Name
                            .Replace('y', 'x')
                            .Contains(txt1.Text));
    }
