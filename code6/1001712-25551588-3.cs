    public static string GetValueFromResponses(IEnumerable<ElementResponseBaseType> responses, string fieldref)
    {
        foreach (ElementResponseBaseType response in responses)
        {
            ElementResponseType element = response as ElementResponseType;
            if (element != null)
            {
                string foundValue = CheckElement(element, fieldref);
                if (foundValue != null)
                {
                    return foundValue;
                }
            }
            else
            {
                GroupResponseType group = response as GroupResponseType;
                if (group != null)
                {
                    string foundValue = GetValueFromResponses(group.Responses, fieldref);
                    if (foundValue != null)
                    {
                        return foundValue;
                    }
                }
            }
        }
    
        return string.Empty;
    }
    
    private static string CheckElement(ElementResponseType element, string fieldref)
    {
        if (element.Element.Reference == fieldref)
        {
            return element.Value;
        }
    
        return null;
    }
