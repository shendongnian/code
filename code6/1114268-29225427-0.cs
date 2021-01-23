    // instead of this
    // var left = Projections.Property<DateTime>(effDate);
    
    // we would use this
    // DateTime effDate is passed in
    var effDate = DateTime.Today.Date; // C#'s today
    var left = Projections.Constant(effDate);
    
    var right = Projects.SqlFunction("COALESCE",
                NHibernateUtil.DateTime,
                Projections.Constant(DateTime.Parse("6/6/2079").Date, NHibernateUtil.DateTime),
                Projections.Property<ProfitCenter>(pc => pc.CloseDate));
