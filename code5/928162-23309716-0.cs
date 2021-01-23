    public class DynamicQuery<T>
        {
            public IEnumerable<T> GetByFieldFilterObjectValue(IEnumerable<T> collection, string colName, object value)
            {
                IEnumerable<T> results = collection.Where(d => d.GetType().GetProperty(colName).GetValue(d, null).Equals(value));
    
                return results;
            }
        }
