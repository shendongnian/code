    string dadada(IEnumerable _elements)
    {
        string link = "null";
    
        if(_elements.Count() > 1)
        {
            link = ((HtmlNode)_elements.Skip(1).First()).SelectSingleNode("a").Attributes[0].Value;
        }
    
        return link;
    }
