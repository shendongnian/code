    // Aliases
    CostAmount costAmount = null;
    Year year = null;
    Month month = null;
    // Projections for the math operations
    // y.Code * 100
    var proj1 = Projections.SqlFunction(
        new VarArgsSQLFunction("(", "*", ")"),
        NHibernateUtil.Int32,
        Projections.Property(() => year.Code),
        Projections.Constant(100)
    );
    // proj1 + m.Code 
    var proj2 = Projections.SqlFunction(
        new VarArgsSQLFunction("(", "+", ")"),
        NHibernateUtil.Int32,
        proj1,
        Projections.Property(() => month.Code)
    );
    // The query
    var query = Session.QueryOver(() => costAmount)
                       .JoinAlias(() => costAmount.Year, () => year)
                       .JoinAlias(() => costAmount.Month, () => month)
                       .Where(Restrictions.Between(proj2, 9107, 9207));
    var res = query.List();
