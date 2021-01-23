    // instead of this
    .Select(x => new { name = string.Format("{0} {1}",
         x.FirstName, x.LastName) })
         .WithAlias(() => businessSectorItem.text))                                   
    // we should use this
    .Select(
        Projections.SqlFunction("concat", 
            NHibernateUtil.String,
            Projections.Property<Employee>(e => e.FirstName),
            Projections.Constant(" "),
            Projections.Property<Employee>(e => e.LastName)
        )).WithAlias(() => businessSectorItem.text)
