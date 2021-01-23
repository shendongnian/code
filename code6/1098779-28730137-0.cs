    var session = new StubIDbSession();
    session.QueryOf1StringObject((sql1, param1) =>
    {
        return new List<string>();
    });
    session.QueryOf1StringObject((sql1, param1) =>
    {
        return new List<int>();
    });
