    public List<T> GetXmlDataSource<T>(string pathToXmlFile) where T : IXmlDataSource
    {
       ...
       // How to return the IEnumerable query to a List of the T's?
       return query.Where(x => x.CommonProperty1).ToList();
    }
