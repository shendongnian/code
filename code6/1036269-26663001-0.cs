    static void TraverseXElement(XElement elem, Dictionary<string, List<string>> aggregation)
    {
        const string valuesKey = "Values";
        const string tagNameKey = "Tag Name";
        const string attributesKey = "Attributes";
        aggregation[tagNameKey].Add(elem.Name.LocalName);
        foreach (var childText in elem.Nodes().OfType<XText>())
        {
            //immediate values, even in case of wrongly formed XML
            aggregation[valuesKey].Add(childText.Value); 
        }
        foreach (var element in elem.Elements())
        {
            TraverseXElement(element, aggregation);
        }
        foreach (var attr in elem.Attributes())
        {
            aggregation[attributesKey].Add(attr.Name.LocalName);
            aggregation[valuesKey].Add(attr.Value);
        }
    }
