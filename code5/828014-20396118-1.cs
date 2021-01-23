    var xEle = new XElement("DataDictionary",
        from fd in factDetails
        group fd by fd.ElementPrefix.Contains("dei") into gr
        select new XElement(gr.Key ? "filingInfo" : "TaggableContent",
                    from emp in gr
                    select new XElement(p.GetParameterType(emp.ElementType,emp.ElementPrefix),
                        new XElement("xbrlElementInfo",
                            new XAttribute("name", emp.ElementName),
                            new XElement("ContentValue", emp.FactValue)))));
