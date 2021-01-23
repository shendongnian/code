    public object GetValue(int i)
    {
       if (_el == null)
       {
          _el = XNode.ReadFrom(_reader) as XElement;
       }
         string SearchString = _columns[i];
       var searchedAttributeValue = from nm in _el.Attributes(SearchString) select nm;
       if (searchedAttributeValue.Count() > 0)
       {
          return ParseTypes(searchedAttributeValue.First().Value);
       }
       var searchedElementValue = from nm in _el.Elements(SearchString) select nm;
       if (searchedElementValue.Count() > 0)
       {
          return ParseTypes(searchedElementValue.First().Value);
       }
        
       throw new Exception("oh crap!");
    }
