    string xml = "<property_set_list><property_set symbol_id=\"TestPropertySet1\"><property symbol_id=\"TestName1\" id=\"1\" type=\"8\">qwerty</property>" +
        "<property symbol_id=\"TestName2\" id=\"1\" type=\"8\"></property></property_set><property_set symbol_id=\"TestPropertySet2\">" +
        "<property symbol_id=\"localeID\" id=\"1\" type=\"19\">1033</property><property symbol_id=\"localeID\" id=\"2\" type=\"19\">1079</property></property_set></property_set_list>";
    XElement xdoc = XElement.Parse(xml);
    XElement TestPropertySet2 = xdoc.Elements()
        .Where(x => x.Attribute("symbol_id").Value == "TestPropertySet2")
        .FirstOrDefault();
    TestPropertySet2.Add(
        new XElement(
           "property", "locale_id_val",
           new XAttribute("symbol_id", "localeID"),
           new XAttribute("id", "99"),
           new XAttribute("type", "19")
           ));
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.Indent = true;
    xws.IndentChars = "\t\t";
    FileStream fs = new FileStream("test.xml", FileMode.Create);
    using (XmlWriter xw = XmlWriter.Create(fs, xws))
    {
         xdoc.Save(xw);
    }
    fs.Close();
