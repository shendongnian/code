    using (var transaction = Session.BeginTransaction())
    {
        var foo = Session.Load<Foo>(fooId);
        Session.Delete(foo);
        transaction.Commit();
    }
    using (var transaction = Session.BeginTransaction())
    {
        gridView.DataSource = Session.List<Foo>(fooId);
        gridView.DataBind()
        transaction.Commit();
    }
