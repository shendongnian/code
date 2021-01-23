    public IEnumerable<int> GetInstances(IList<Vector> featureVectors)
    {
        var result = new List<int>();
        for (int instance = 0; instance < featureVectors.Count; instance++)
        {
           result.Add(instance);
        }
        return result;
    }
