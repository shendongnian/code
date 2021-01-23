    if (tempName != null)
    {
        tempElement.ElementName = tempName.Value;
    }
    if (tempType == null)
    {
        tempElement.ElementType = "<<< No Type >>>";
        element.Elements.Add(tempElement);
    }
    else
    {
        var tempTypeValue = tempType.Value.Substring(tempType.Value.IndexOf(":") + 1, tempType.Value.Length - tempType.Value.IndexOf(":") - 1);
        if (tipovi.Contains(tempTypeValue))
        {
            tempElement.ElementType = tempTypeValue;
            element.Elements.Add(tempElement);
        }
        else
        {
            XElement complexTypeUsedByElement = GetComplexType(tempTypeValue);
            element.Elements.Add(ParseComplexType(complexTypeUsedByElement, tempName.Value));
        }
    }
