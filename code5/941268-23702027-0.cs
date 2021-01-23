    public class GenericDirectoryObject<T> : DirectoryObject
    {
        public IEnumerable<T> GetUsers()
        {
            PagedResults pagedResults = _graphConnection.List<T>(null, null);
            return pagedResults.Results.OfType<T>();
        }
    }
