    public IEnumerable<int> GetInstances(IList<Vector> featureVectors)
    {
        for (int instance = 0; instance < featureVectors.Count; instance++)
        {
            yield return instance;
        }
    }
