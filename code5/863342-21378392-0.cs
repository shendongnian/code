    public class YourClass
    {
        public T[] Search<T>(string search, Convertor<SearchResult, T> convertor)
        {
            ...
            List<SearchResult> results = ...
            return results.ConvertAll(convertor).ToArray();
        }
    }
