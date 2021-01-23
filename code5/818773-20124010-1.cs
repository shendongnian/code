    public DetachedCriteria GetDetachedCriteria(List<int> ids)
    {
        return DetachedCriteria
                .For<PageCategory>()
                .SetProjection(Projections.ProjectionList().Add(Projections.Property("ID")))
                .Add(Restrictions.In("CategoryID", ids))
                .Add(Restrictions.EqProperty("TestObject", "test.ID"));
    }
