    string dadada(IEnumerable _elements)
    {
        string link = "null";
    
        if(_elements.Any())
        {
            link = ((HtmlNode)_elements.First()).SelectSingleNode("a").Attributes[0].Value;
        }
    
        return link;
    }
