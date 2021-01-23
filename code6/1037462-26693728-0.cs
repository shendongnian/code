    string xmlResultString = @"<ResultData xmlns=""http://schemas.datacontract.org/2004/07/TsmApi.Logic.BusinesEntities"" 
    xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    <Information>Schedule added.</Information>
    <Success>true</Success>
    </ResultData>";
    
    var doc = XDocument.Parse(xmlResultString);
    
    foreach (var element in doc.Descendants())
    {
        element.Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
        element.Name = element.Name.LocalName;
    }
    xmlResultString = doc.ToString();
    var rdr = new StringReader(xmlResultString);
    var serializer = new XmlSerializer(typeof(ResultData));
    var resultingMessage = (ResultData)serializer.Deserialize(rdr);
