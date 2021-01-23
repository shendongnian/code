    bool called = false;
    session.QueryOf1StringObject((sql1, param1) =>
    {
        if(called)
        {
            return new List<string> { "STRING 2" };
        }
        else
        {
            called = true;
            return new List<string> { "STRING 1" }
        }
    });
