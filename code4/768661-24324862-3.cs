    [Test]
    public void TestRulesUsingList()
        var rules = new IRules[]{ new RuleNumberOne(), new RuleNumberTwo() };
        var date = new Oobject { Time = 1, Something = 1 };
        var rate = 0m;
        foreach(var rule in rules)
            rate = rule.Execute(date);
        Assert.That( rate, Is.EqualTo(.75m));
    }
