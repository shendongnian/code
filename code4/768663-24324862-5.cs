    var map = new Dictionary<Func<Oobject, bool>, decimal>
    {
        { x => x.Time > 0 && x.Something <= 499, .75m },
        { x => x.Time >= 500 && x.Something <= 999, .85m },
        { x => true, 0 }
    };
    var date = new Oobject { Time = 1, Something = 1 };
    var rate = map.First(x => x.Key(date)).Value;
    Assert.That( rate, Is.EqualTo(.75m));
