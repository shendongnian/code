    public abstract DictionaryAsDTO<T> : IReadOnlyDictionary<string, object>
    {
        protected DictionaryAsDTO(T t, string listOfProperties)
        {
            // Populate an internal dictionary with subset of t's props based on string
        }
    }
