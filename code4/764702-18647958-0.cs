    // not production-quality code
    public WorldViewModel(GameContainer container)
    {
    	foreach (var population in container.Regions.SelectMany(x => x.Settlements).SelectMany(x => x.Population))
    	{
            population.CollectionChanged += (s,e) => RecalculateCount(container);
    	}
    	
    	RecalculateCount();
    }
    
    private static void RecalculateCount(GameContainer container)
    {
    	GlobalPopulation = container.Regions
    				.SelectMany(x => x.Settlements)
    				.SelectMany(x => x.Population)
    				.Distinct()
    				.Count();
    }
