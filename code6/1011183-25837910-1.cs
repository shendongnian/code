    using(session = NHibernateHelper.OpenSession())
    {
    var TagObjectFromDb = session.Get<Tag>(id);
    NHibernateUtil.Initialize(TagObjectFromDb.Feed);//initialize lazy collection, 
    return TagObjectFromDb;
    }
