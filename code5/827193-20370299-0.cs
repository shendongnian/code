    System.Xml.XmlWriterSettings xws = new System.Xml.XmlWriterSettings();
    xws.Indent = true;
    xws.IndentChars = "\t";
    FileStream fsConfig = new FileStream(path, FileMode.Create);
    using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(fsConfig, xws))
    {
           doc.Save(xw);
    }
    fsConfig.Close();
