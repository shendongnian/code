    Dictionary<string, Func<IStrategy>> factories = new Dictionary<string, Func<IStrategy>>();
    //register various factories
    factories.Add("StrategyA", () => new StrategyA(value));
    factories.Add("StrategyB", () => new StrategyB(date));
    
    Func<IStrategy> factory;
    if(factories.TryGetValue(strategyName, out factory))
    {
        IStrategy instance = factory();
    }
