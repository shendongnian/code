    protected string FormatXml(string xmlFile)
    {
        XmlDocument doc = new XmlDocument();
        FileStream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read);
        doc.Load(fs);
        StringBuilder sb = new StringBuilder();
        System.IO.TextWriter tr = new System.IO.StringWriter(sb);
        XmlTextWriter wr = new XmlTextWriter(tr);
        wr.Formatting = Formatting.Indented;
        doc.Save(wr);
        wr.Close();
        return sb.ToString();
    }
