    var d1 = new XmlDocument();
    d1.LoadXml("<Tags><Tag name =\"1\"></Tag></Tags>");
		
    var d2 = new XmlDocument();
    d2.LoadXml("<Tags><Tag name =\"2\"></Tag></Tags>");
		
    var newNode = d1.ImportNode(d2.SelectSingleNode("/Tags/Tag"), true);
    d1.DocumentElement.AppendChild(newNode);
		
    Console.WriteLine(d1.OuterXml);
