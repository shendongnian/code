    using(var session = SessionFactory.OpenSession())
    using(var tr = session.BeginTransaction())
    {
       var rep1 = new SomeRepository1(session);
       rep1.DoSomeJob();
       var rep2 = new SomeRepository2(session);
       rep2.DoSomeOtherJob();
       tr.Commit();
    }
