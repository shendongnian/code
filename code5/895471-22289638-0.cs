    var t = typeof(List<>).MakeGenericType(typeof(string));
    var list = (System.Collections.IList)Activator.CreateInstance(t);
    list.Add("string1");
    list.Add("string2");
    
    var serialiser = new System.Xml.Serialization.XmlSerializer(list.GetType());
    var writer = new System.IO.StringWriter();
    serialiser.Serialize(writer, list);
    
    var result = writer.GetStringBuilder().ToString();
