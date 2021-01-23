    string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
    string xmlfilepath = Path.Combine(appPath, "SNG.xml");
    
    XDocument xdoc = XDocument.Load(xmlfilepath);
    var attrib = xdoc.Root.Attribute("BookRef").Value;
