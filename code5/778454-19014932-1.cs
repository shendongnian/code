    // Returns min/max/average, ignoring null elements
    Tuple<float,float,float> ComputeStats(IEnumerable<float?> values)
    {
         float min = float.MaxValue;
         float max = float.MinValue;
         float total = 0.0;
         int count = 0;
         foreach(var value in values)
         {
            if (value.HasValue)
            {
                min = Math.Min(min, value.Value);
                max = Math.Max(max, value.Value);
                total += value.Value;
                ++count;
            }
         }
         return Tuple.Create(min, max, total / count);
    }
