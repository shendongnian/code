    var monthProjection = Projections
         .SqlProjection(" MONTH(Data) as month "  // the left side of the expression
                       , new[] {"month"}          // alias  
                       , new IType[] {NHibernateUtil.Int32}); // type is int
    criteria.Add(Expression.Eq(monthProjection, anoInicio));
