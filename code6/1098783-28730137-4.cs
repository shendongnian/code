    var session = new StubIDbSession();
    session.QueryOf1StringObject((sql1, param1) =>
    {
        return new List<string> { "STRING 1" }
    });
    session.QueryOf1StringObject((sql1, param1) =>
    {
        return new List<string> { "STRING 2" }
    });
