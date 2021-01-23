    string ProcessAll()
    {
        return ConvertToJsonString(
            database.
            Get<XAccount>().
            Where(a => a.Enabled).
            AsParallel().
            Select(a => new
            {
                Id = a.Id,
                Success = HeavyProcessing(a)
            }).
            ToArray());
    }
