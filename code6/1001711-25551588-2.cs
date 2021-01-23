    public static string GetValueFromResponses(IEnumerable<ElementResponseBaseType> responses, string fieldref)
    {
        var foundInElements = responses.OfType<ElementResponseType>()
                                       .Select(e => CheckElement(e, fieldref));
        var foundInGroups = responses.OfType<GroupResponseType>()
                                     .Select(g => GetValueFromResponses(g.Responses, 
                                                                        fieldref));
    
        return foundInElements.Concat(foundInGroups)
                              .FirstOrDefault(s => s != null) ?? string.Empty;
    }
    
    private static string CheckElement(ElementResponseType element, string fieldref)
    {
        if (element.Element.Reference == fieldref)
        {
            return element.Value;
        }
    
        return null;
    }
