    ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
        .CreateCriteria(typeof(Tag))
        .CreateAlias("Bookmarks", "b", JoinType.LeftOuterJoin)
        .CreateAlias("b.Tags", "bt", JoinType.LeftOuterJoin)
        .CreateAlias("User", "User")
        .Add(Restrictions.Eq("Title", title))
        .Add(Restrictions.Eq("User.Username", username))
        .SetResultTransformer(Transformers.DistinctRootEntity);
