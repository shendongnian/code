    private static string RemoveHeightsAndWidths(string original)
    {
        XElement element = XElement.Parse(original);
        var tableRelatedElements =
            element.Descendants("table")
            .Union(element.Descendants("tr"))
            .Union(element.Descendants("td"))
            .Union(element.Descendants("th")); //add more items you want to strip the height and width from in the same manner
            
        Regex reg = new Regex("(?:width:.*?;)|(?:height:.*?;)");
        foreach (var item in tableRelatedElements)
        {
            if (item.Attributes("style").Any())
            {
                item.Attribute("style").Value = reg.Replace(item.Attribute("style").Value, string.Empty);
            }
            if (item.Attributes("height").Any())
            {
                item.Attribute("height").Remove();
            }
            if (item.Attributes("width").Any())
            {
                item.Attribute("width").Remove();
            }
        }
        return element.ToString();
    }
