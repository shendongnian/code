    public string MaxDepartment<TLastUpdatable>(IEnumerable<TLastUpdatable> updatables) where TLastUpdatable : class, ILastUpdatable
    {
        var results = updatables.Max(t => t.LastUpdated);
        string hex = BitConverter.ToString(results);
        hex =  hex.Replace("-", "");
        return hex;
    }
