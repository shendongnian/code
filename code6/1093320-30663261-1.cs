    public IEnumerable<T> GetAll()
    {
        var results = new List<T>();
        var conventions = _documentStore.Conventions ?? new DocumentConvention();
        var defaultIndexStartsWith = conventions.GetTypeTagName(typeof(T));
        using(var session = _documentStore.OpenSession())
        {
            using(var enumerator = session.Advanced.Stream<T>(defaultIndexStartsWith))
            {
                while(enumerator.MoveNext())
                    results.Add(enumerator.Current.Document);
            }
        }
        return results;
    }
