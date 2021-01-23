    //This line will remove the null as i earlier mentioned in my question.
    string jsonStatus = JsonConvert.SerializeObject(myJson, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    //Create xml object by covnert json into xml
    XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
    
    //Get the property name which have the value 0
    var v = doc.GetElementsByTagName("value")[0];
    
    //Remove the child node.
    doc.DocumentElement.RemoveChild(v);
    //Again convert into the json.
    string jsonText = JsonConvert.SerializeObject(doc);
