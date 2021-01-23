    public object GetValue(int i)
    {
        string searchString = _columns[i];
        var searchedAttribute = _el.Attributes(searchString).FirstOrDefault();
        if (searchedAttribute != null)
        {
            return ParseTypes(searchedAttribute.Value);
        }
        var searchedElement = _el.Elements(searchString).FirstOrDefault();
        if (searchedElement != null)
        {
            return ParseTypes(searchedElement.Value);
        }
        // Nothing found - oops.
        throw new SomeSpecificException("Some message here");
    }
