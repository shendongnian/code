    XmlDocument xmlDOC = new XmlDocument();
       xmlDOC.LoadXml(periodID_Value_Before_OffSet); // string storing my XML 
       var value = xmlDOC.GetElementsByTagName("value");
       var xmlActions = new string[value.Count];
       string values = "";
       string Period1 = "";
       string periodlevel_period1 = "";
       List<string> modified_listofstrings = new List<string>();
       string arrayOfStrings = ""; 
       for (int i = 0; i < value.Count; i++)
       {
           var xmlAttributeCollection = value[i].Attributes;
           if (xmlAttributeCollection != null)
           {
               var action = xmlAttributeCollection["periodid"];
               xmlActions[i] = action.Value;
               values += action.Value + ",";
               string vals = values.Split(',')[1];
               string counts = values;
               string[] periods = counts.Split(',');
               Period1 = periods[i];
               // periodlevel_period1 = QPR_webService_Client.GetAttributeAsString(sessionId, Period1, "name", "");
               modified_listofstrings.Add(QPR_webService_Client.GetAttributeAsString(sessionId, Period1, "name", ""));
           }
       }
    return modified_listofstrings;
