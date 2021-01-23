        doc = new XDocument(
            new XElement(xmlns + "displayMLResponse",
                new XAttribute("xmlns", "http://www.peek.se/DisplayML/"),
                new XAttribute("version", "1.12"),
                new XAttribute("dateTime", date),
                new XElement("getStatusResponse")));
        XElement ele = doc.Root.Element("getStatusResponse");
        if (systemInformationList.Count != 0)
        {
            ele.Add(new XElement("systemInformation",
                        systemInformationList.Select(info => new XElement("item",
                            new XElement("name", info.name),
                            new XElement("value", info.value))).Where(item => item != null)));
        }
        if(responceList.Count != 0)
        {
            ele.Add(responceList.Select(fault => 
                        new XElement("faults",
                            new XElement("systemFault",
                                new XElement(fault.faultType,
                                    new XAttribute("description", fault.description),
                                    fault.name.Length == 0 ? new XAttribute("name", fault.name) : null,
                                    fault.size.Length == 0 ? new XAttribute("size", fault.size) : null)))));
        } else
        {
            ele.Add(new XElement("OK"));
        }
