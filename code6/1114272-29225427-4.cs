    var right = Projects.SqlFunction("COALESCE",
        NHibernateUtil.DateTime,
        // As DOC of COALESCE says:
        // "Evaluates the arguments in order and returns the current value of 
        //  the first expression that initially does not evaluate to NULL."
        Projections.Property<ProfitCenter>(pc => pc.CloseDate), 
        Projections.Constant(DateTime.Parse("6/6/2079").DateNHibernateUtil.DateTime)
        );
