    var right = Projects.SqlFunction("COALESCE",
        NHibernateUtil.DateTime,
        // be sure that column goes to correct table
        // ==> use the same alias
        Projections.Property(() => pca.CloseDate), 
        Projections.Constant(DateTime.Parse("6/6/2079").DateNHibernateUtil.DateTime)
        );
