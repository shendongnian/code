        XElement xelem = XElement.Parse("<root><AA><BB>BB</BB></AA></root>");
        MyObj myObj = new MyObj();
        
        XmlSerializer ser = new XmlSerializer(typeof(MyObj));
        foreach (XElement reqitem in xelem.Descendants("AA"))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, myObj);                
                reqitem.Add(XElement.Parse(Encoding.UTF8.GetString(ms.ToArray())));
                
            }
        }
