    private static IEnumerable<Tuple<DateTime, string, string>> GetDocumentsData(string folderPath)
    {
        var filingMessageNamespace = XNamespace.Get("urn:oasis:names:tc:legalxml-courtfiling:schema:xsd:CoreFilingMessage-4.0");
        var ncNamespace = XNamespace.Get("http://niem.gov/niem/niem-core/2.0");
        var ecfNamespace = XNamespace.Get("urn:oasis:names:tc:legalxml-courtfiling:schema:xsd:CommonTypes-4.0");
        var jNamespace = XNamespace.Get("http://niem.gov/niem/domains/jxdm/4.0");
        return Directory
            .GetFiles(folderPath, "XML*.xml")
            .Select(XDocument.Load)
            .SelectMany(
                file => 
                    file.Descendants(filingMessageNamespace + "FilingLeadDocument")
                    .Concat(file.Descendants(filingMessageNamespace + "FilingConnectedDocument")))
            .Select(
                documentNode =>
                    Tuple.Create(
                        DateTime.Parse(documentNode.Element(ncNamespace + "DocumentReceivedDate").Element(ncNamespace + "DateTime").Value),
                        documentNode.Element(ncNamespace + "DocumentDescriptionText").Value.Trim(),
                        documentNode.Element(ecfNamespace + "DocumentMetadata").Element(jNamespace + "RegisterActionDescriptionText").Value.Trim()))
            .ToArray();
    }
