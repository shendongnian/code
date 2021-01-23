    using (ISession session = NHibernateHelper.OpenSession())
    using (ITransaction tx = session.BeginTransaction())
    {
        IList<Student> results = session.QueryOver<Student>()
                                 .Fetch(d => d.Projects).Eager
                                 .Fetch(d => d.Classes).Eager
                                 .Fetch(d => d.Books).Eager
                                 .TransformUsing(Transformers.DistinctRootEntity)
                                 .List<Student>();
        tx.Commit();
    }
