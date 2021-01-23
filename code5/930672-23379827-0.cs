     var doc = XDocument.Parse("your xml string");
     foreach (var item in doc.Descendants("DataSet"))
        {
            var str = new StringBuilder();
            var str1 = new StringBuilder();
            str.Append("<Field Name='CommunicationDataValueId'>");
            str.Append("<DataField>CommunicationDataValueId</DataField>");
            str.Append("<TypeName>System.Int64</TypeName>");
            str.Append("</Field>");
            str1.Append("<Field Name='DeviceMasterId'>");
            str1.Append("<DataField>DeviceMasterId</DataField>");
            str1.Append("<TypeName>System.Int32</TypeName>");
            str1.Append("</Field>");
            item.Add(XElement.Parse(str.ToString()));
            item.Add(XElement.Parse(str1.ToString()));
        }
