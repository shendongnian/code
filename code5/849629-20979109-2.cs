    using (SepasProjectEntities sp = new SepasProjectEntities())
    {
        var query = sp.HISAccidentLocationmappings
                        .Where(p => p.Name != null
                            && p.Name
                                .Replace("y", "x")
                                .Contains(txt1.Text))
                        .ToList();
    }
