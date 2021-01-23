    var list = session.QueryOver<MyTable>()
        .Where(
            Restrictions.Or(
              Restrictions.Eq(Projections.Property<MyTable>(tab => tab.x), "One"),
              Restrictions.Eq(Projections.Property<MyTable>(tab => tab.y), "Two")
            )
        )
        .List<MyTable>()
