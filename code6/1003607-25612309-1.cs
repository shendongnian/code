    public IEnumerable<IEnumerable<TObject>> Algo<TObject>(IEnumerable<TObject> source, int groups,
                                                           Func<TObject, int> intSelector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
    
        source = source.OrderByDescending(intSelector);
        var evaluated = source as IList<TObject> ?? source.ToList();
        if (groups > evaluated.Count())
        {
            throw new ArgumentException("Invalid group count.");
        }
    
        var result = new List<List<TObject>>();
        for (var i = 0; i < groups; i++)
        {
            result.Add(new List<TObject> { evaluated[i] });
        }
    
        for (var i = groups; i < evaluated.Count(); i++)
        {
            var bestIndex = 0;
            var bestSum = result[bestIndex].Sum(intSelector);
            for (var j = 1; j < result.Count; j++)
            {
                var sum = result[j].Sum(intSelector);
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
