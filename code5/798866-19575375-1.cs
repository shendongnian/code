    public List<T> GetXmlDataSource<T>(string pathToXmlFile, 
                                       string elementName,     
                                       Func<XElement,T> factoryMethod)
    {
    ...
       IEnumerable<T> query = from s in xml.Descendants(elementName)
                                           select factoryMethod(s);
    ...
    }
