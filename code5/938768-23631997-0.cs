    using (MyEntities context = GetMyEntites())
    {
        var query = context.Table1
            .Where(t1 => t1.FilterColumn == filter1)
            Project().To<MyViewModel>();
        return query.ToList();
    }
