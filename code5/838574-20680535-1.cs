    public static class YourStaticMethods
    {
           public static XDocument GetXDocument(this OpenXmlPart part)
            {
                XDocument xdoc = part.Annotation<XDocument>();
                if (xdoc != null)
                    return xdoc;
                using (Stream str = part.GetStream())
                using (StreamReader streamReader = new StreamReader(str))
                using (XmlReader xr = XmlReader.Create(streamReader))
                    xdoc = XDocument.Load(xr);
                part.AddAnnotation(xdoc);
                return xdoc;
            }
    }
