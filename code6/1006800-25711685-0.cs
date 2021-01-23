    public IEnumerable<Weight> GetSortedWeights()
    {
        var weights = new List<Weight>() { new Weight { Date = DateTime.Now, BodyWeight = 80 }, ... };
    
        return weights.OrderBy(x => x.Date);
    }
