    .OrderBy
    (
        Projections.Conditional(
            Restrictions.Where<House>(r => r.Name.IsLike("starks")),
            Projections.Constant(1),
            Projections.Conditional(
                Restrictions.Where<House>(r => r.Name.IsLike("wildlings")),
                Projections.Constant(2),
                Projections.Conditional(
                    Restrictions.Where<House>(r => r.Name.IsLike("lannisters")),
                    Projections.Constant(3),
                    Projections.Constant(0)
                    )
                )
            )
    )
    .Asc()
