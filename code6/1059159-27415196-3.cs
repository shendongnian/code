    List<IStrategy> strategies = new List<IStrategy>();
    //register strategies (highest priority first)
    strategies.Add(new StrategyA(value));
    strategies.Add(new StrategyB(value));
    //alternatively, you might resolve IEnumerable<IStrategy> from your IoC container
    
    foreach(IStrategy strategy in strategies)
    {
        if(strategy.IsApplicable(someInput)) return strategy;
    }
