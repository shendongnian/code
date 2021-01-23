    NHibernateUtil.Initialize(yourObject);
    NHibernateUtil.Initialize(yourObject.List1);
    NHibernateUtil.Initialize(yourObject.OtherList);
    ...etc...
    SerializeObject(yourObject);
