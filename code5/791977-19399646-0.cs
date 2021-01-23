    private static string ExtractIngredients(XElement v)
    {
        var ingredients = v
            .Elements("ingrediens")
            .Select(e => 
                e.DescendantNodes().OfType<XText>().First().Value +
                ": " +
                e.Element("mangd").Value);
        
        return String.Join("\r\n", ingredients);
    }
