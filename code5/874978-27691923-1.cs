    public static void PutXDocument(this OpenXmlPart part)
    {
        XDocument xdoc = part.GetXDocument();
        if (xdoc != null)
        {
            // Serialize the XDocument object back to the Package.
            using (XmlWriter xw = XmlWriter.Create( part.GetStream( FileMode.Create, FileAccess.Write )))
            {
                xdoc.Save( xw );
            }
        }
    }
