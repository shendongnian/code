    public IEnumerable<Table1> GetAllCoilLengthSettingsWithChilds(string param, double[] Thicknesses)
    {
        // Base query
        var query = DBContext.Table1.Where(c => c.Field1 == param);
        // All the various || between the Thickness ranges
        var predicate = PredicateBuilder.False<Table1>();
        foreach (double th in Thicknesses)
        {
            // Don't want a closure around th
            double th2 = th;
            predicate = predicate.Or(c => th2 >= c.MinThickness && th2 <= c.MaxThickness);
        }
        // This is implicitly in && with the other Where
        query.Where(predicate);
        
        return query.ToList();
    }
