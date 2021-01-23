    ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
        .CreateCriteria(typeof(Tag))
        .CreateAlias("Bookmarks", "b", JoinType.LeftOuterJoin)
        .SetFetchMode("b.Tags", FetchMode.Eager)
        .CreateAlias("User", "User")
        .Add(Restrictions.Eq("Title", title))
        .Add(Restrictions.Eq("User.Username", username));
