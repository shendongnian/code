    from p in samples.Elements("samples").Elements("measurement").Elements("param")
    group (double)p by (string)p.Attribute("name") into grp
    select new
    {
        ParameterName = grp.Key,
        Min = grp.Min(),
        Avg = grp.Average(),
        Max = grp.Max()
    }
