    public IEnumerable<IEnumerable<int>> Algo(IEnumerable<int> source, int groups)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
    
        source = source.OrderByDescending(i => i);
    
        var evaluated = source as IList<int> ?? source.ToList();
        if (groups > evaluated.Count())
        {
            throw new ArgumentException("Invalid group count.");
        }
    
        var result = new List<List<int>>();
        for (var i = 0; i < groups; i++)
        {
            result.Add(new List<int> { evaluated[i] });
        }
    
        for (var i = groups; i < evaluated.Count(); i++)
        {
            var bestIndex = 0;
            var bestSum = result[bestIndex ];
            for (var j = 1; j < result.Count; j++)
            {
                var sum = result[j].Sum();
                if (sum < bestSum)
                {
                    bestSum = sum;
                    bestIndex = j;
                }
            }
    
            result[bestIndex].Add(evaluated[i]);
        }
    
        return result;
    }
