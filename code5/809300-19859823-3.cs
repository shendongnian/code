    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(periodID_Value_Before_OffSet); // string storing my XML 
    var items = doc.GetElementsByTagName("value");
    var xmlActions = new string[items.Count];
    for (int i = 0; i < items.Count; i++)
    {
        var xmlAttributeCollection = items[i].Attributes;
        if (xmlAttributeCollection != null)
        {
            var action = xmlAttributeCollection["value"];
            xmlActions[i] = action.Value;
            string values = "";
            values += action.Value + ",";
        }
    }
