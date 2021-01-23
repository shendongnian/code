    var d = new Data();
    var s = new XmlSerializer(d.GetType());
    var sb = new StringBuilder();
    var strStream = new StringWriter(sb);
    s.Serialize(strStream, d);
    Trace.WriteLine(sb.ToString());// formatted document
    
    var xd = new XmlDocument();
    xd.LoadXml(sb.ToString());
    Trace.WriteLine(xd.OuterXml); // document without any surplus space character or linebreaks
