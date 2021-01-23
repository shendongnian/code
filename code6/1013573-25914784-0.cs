    BsonClassMap.RegisterClassMap<Measurement>(m =>
    {
        m.MapProperty(x => x.MyMessage1);
        m.MapProperty(x => x.MyMessage2);
        m.MapProperty(x => x.MyMessage3);
    });
