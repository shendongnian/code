    // left side
    var left = Projections.Property<ExpenseReport>(ti => ti.PeriodFrom);
    // right side
    var right = Projections.SqlFunction("COALESCE"
            , NHibernateUtil.DateTime
            , Projections.Constant(search.DateFrom, NHibernateUtil.DateTime)
            , Projections.Property<ExpenseReport>(ti => ti.PeriodFrom)
        );
    // the restriction using the GeProperty, taking two IProjections
    var restriction = Restrictions.GeProperty(left, right);
    // finally - our query get its WHERE
    q.Where(restriction);
