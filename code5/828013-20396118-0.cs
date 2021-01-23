    var fillingIngo = 
        from emp in factDetails
        where emp.ElementPrefix.Contains("dei")
        select new XElement(p.GetParameterType(emp.ElementType,emp.ElementPrefix),
                    new XElement("xbrlElementInfo",
                        new XAttribute("name", emp.ElementName),
                        new XElement("ContentValue", emp.FactValue)));
                
    var taggableContent = 
        from emp in factDetails
        where !emp.ElementPrefix.Contains("dei")
        select new XElement(p.GetParameterType(emp.ElementType,emp.ElementPrefix),
                new XElement("xbrlElementInfo",
                    new XAttribute("name", emp.ElementName),
                    new XElement("ContentValue", emp.FactValue)));
    
    
    
    var result = new XElement(
        "DataDictionary",
        new[]
            {
                new XElement("filingInfo", fillingIngo), 
                new XElement("TaggableContent", taggableContent)
            });
