    var xslt = new XslCompiledTransform();
    xslt.Load(HttpContext.Current.Server.MapPath("~/XML/CareLog.xsl"));
    var settings = xslt.OutputSettings.Clone();
    settings.NewLineChars = "\n";
    settings.NewLineHandling = NewLineHandling.Replace;
    using (var reader = XmlReader.Create("example.xml"))
    {
     using (var writer = XmlWriter.Create("yourDoc.txt", settings))
     {
       xslt.Transform(reader, writer);
     }
    }
