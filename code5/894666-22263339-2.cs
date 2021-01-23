    public static string GetXmlText(XmlDocument doc)
    {
        StringWriter stringWriter = new StringWriter();
        XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
        doc.WriteTo(xmlTextWriter);
        string ret = stringWriter.ToString();
        ret = ret.Replace(Environment.NewLine, string.Empty);
        if (!ret.Contains("xml version="))
        {
            return PrefixXml + ret;
        }
        return ret;
    }
