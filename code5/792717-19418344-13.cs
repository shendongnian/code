    XmlDocument xDoc = new XmlDocument();
    xDoc.Load("E:\\test.xml");
    XmlNodeList xE = xDoc.SelectNodes("//MovieData/Movie/LengthMin");
    if (xE != null)
    {
        for (int iVal = 0; iVal < xE.Count; iVal++)
        {
            if (xE[iVal] is XmlNode)
            {
                XmlElement xNewChild = xDoc.CreateElement("Image");
                xNewChild.InnerText = "string";
                XmlNode commonParent = xE[iVal].ParentNode;
                commonParent.InsertAfter(xNewChild, xE[iVal]);
            }
        }
        xDoc.Save("D:\\test.xml");
    }
      
