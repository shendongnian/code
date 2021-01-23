    return Directory
             .GetFiles(folderPath, "*.xml")
             .Select(XDocument.Load)
             .SelectMany(file => file.Descendants(filingMessageNamespace + "FilingLeadDocument").Concat(file.Descendants(filingMessageNamespace + "FilingConnectedDocument")))
             .Select(documentNode =>
                     new object[]
                     {
                        (string)documentNode.Parent.Parent.Element(ncNamespace + "DocumentIdentification"),
                        DateTime.Parse(documentNode.Element(ncNamespace + "DocumentReceivedDate").Element(ncNamespace + "DateTime").Value),
                        documentNode.Element(ncNamespace + "DocumentDescriptionText").Value.Trim(),
                        documentNode.Element(ecfNamespace + "DocumentMetadata").Element(jNamespace + "RegisterActionDescriptionText").Value.Trim(),
                        }).ToArray();
        
