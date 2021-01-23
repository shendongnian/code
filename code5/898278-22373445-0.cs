    [Test]
    public void Distinct_with_anonymous_type()
    {
        var items = new[]
        {
            new {p1 = 'a', p2 = 2, p3=10},   // double over p1 and p2
            new {p1 = 'a', p2 = 3, p3=11}, 
            new {p1 = 'a', p2 = 2, p3=12},   // double over p1 and p2
        };
        var expected = new[]
        {
            new {p1 = 'a', p2 = 2},
            new {p1 = 'a', p2 = 3}, 
        };
        var distinct = items.Select(itm => new { itm.p1, itm.p2 }).Distinct();
        Assert.That(distinct, Is.EquivalentTo(expected));
    }
