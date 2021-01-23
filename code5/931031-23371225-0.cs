    if (!string.IsNullOrEmpty(status))
    {
        XmlElement statusElement = xmlDocument.CreateElement("Status");
        statusElement.InnerText = status;
        customerElement.AppendChild((XmlNode)statusElement);
    }
