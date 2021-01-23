    [TestMethod]
    public void TestMethod()
    {
        using (var session = _store.OpenSession())
        {
            session.Store(new Level{ Number = 2828});
            session.Store(new Level { Number = 8583 });
            session.Store(new Level { Number = 3751 });
            session.Store(new Level{ Number = 1});
            session.SaveChanges();
            RavenQueryStatistics statistics;
            var query = session.Query<Level, Level_ByNumber>().Customize(c => c.WaitForNonStaleResults()).Statistics(out statistics).OrderBy(x => x.Number);
                
            var results = query.ToList();
            Assert.AreEqual(1, results[0].Number);
            Assert.AreEqual(2828, results[1].Number);
            Assert.AreEqual(3751, results[2].Number);
            Assert.AreEqual(8583, results[3].Number);//all pass
        }
    }
