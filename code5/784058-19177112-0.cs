    public static class Extend
        {
            public static double StandardDeviation(this IEnumerable<double> values)
            {
                double avg = values.Average();
                var newValues = new List<double>();
                foreach (var v in values)
                {
                    newValues.Add(Math.Pow(v - avg, 2));
                }
    
                return Math.Sqrt(newValues.Average());
            }
        }
