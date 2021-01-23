    data.AddOrUpdate(key, test, (k, t) =>
    {
        var newTest = new Test { Id = t.Id, Val = t.Val };
        if (External)
            newTest.Val += 100;
        else
            newTest.Val -= 100;
        return newTest;
    });
