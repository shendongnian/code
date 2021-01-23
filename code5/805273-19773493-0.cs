    var e2 = new Entity2();
    using (var tx = session.BeginTransaction())
    {
        session.Save(e2);
        session.Save(new Entity1 { Dictionary = { { e2, new Entity3() } } }); // should work
        session.Save(new Entity1 { Dictionary = { { new Entity2(), new Entity3() } } }); // does not work
        tx.Commit();
    }
