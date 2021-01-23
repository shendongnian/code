    private List<IRules>_rules = new List<IRules>();
    public SomeConstructor()
    {
        _rules.Add(new RuleNumberOne());
        _rules.Add(new RuleNumberTwo());
    }
    public void DoSomething()
    {
        Oobject date = new Oobject();
        foreach(var rule in this._rules)
        {
            Decimal rate = rule.Execute(date);
        }
    }
