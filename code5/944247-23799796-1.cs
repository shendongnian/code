    public abstract class Chart<T> where T : PointBase, new()
    {
        public abstract IDictionary<string, T> GetCategoriesData(string serie);
    
        public IDictionary<string, T[]> GenerateSeriesDataDictionary<T>(string[] series, string[] categories)
        {
            // Call GetCategoriesData, etc.
        }
    }
