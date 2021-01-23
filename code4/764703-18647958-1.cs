    // not production-quality code
    public WorldViewModel(GameContainer container)
    {
    	foreach (var region in container.Regions)
        {
            region.CollectionChanged += (s,e) => RecalculateCount(container);
            foreach(var settlement in region.Settlements)
            {
                settlement.CollectionChanged += (s,e) => RecalculateCount(container);
                foreach( var population in settlement.Population)
                {
                    population.CollectionChanged += (s,e) => RecalculateCount(container);
                }        
            }
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
