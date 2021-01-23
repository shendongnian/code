    // Returns min/max/average
    Tuple<double,double,double> ComputeStats(List<double> values)
    {
         double min = double.MaxValue;
         double max = double.MinValue;
         double total = 0.0;
         foreach(var value in values)
         {
            min = Math.Min(min, value);
            max = Math.Max(max, value);
            total += value;
         }
         return Tuple.Create(min, max, total / values.Count);
    }
