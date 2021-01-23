    private static string RemoveHeightsAndWidths(string original)
    {
        XElement element = XElement.Parse(original);
        var tables = element.Descendants("table");
        var styles = tables.SelectMany(t => t.Descendants().Where(d => d.Attributes("style").Any())).Select(x => x.Attribute("style"));
        Regex reg = new Regex("(?:width:.*?;)|(?:height:.*?;)");
        foreach (var item in styles)
        {
            item.Value = reg.Replace(item.Value, string.Empty);
        }
        foreach (var item in tables.Descendants().SelectMany(x => x.Attributes()).Where(x => x.Name == "height" || x.Name == "width"))
        {
            item.Remove();
        }
        foreach (var item in tables.Where(t=> t.Attributes("style").Any()))
        {
            item.Attribute("style").Value = reg.Replace(item.Attribute("style").Value, string.Empty);
        }
        return element.ToString();
    }
