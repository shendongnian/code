    foreach (var f in filenames) {
        string text;
        using (StreamReader s = new StreamReader(f,Encoding.UTF8)) {
            text = s.ReadToEnd();
        }
        text = text.Replace("\x01",@"&#01"); //replace the content
        
        //load some settings
        var resolver = new XmlUrlOverrideResolver();
        resolver.DtdFileMap[@"X1.DTD"] = @"\\location\X1.DTD";
        resolver.DtdFileMap[@"R2.DTD"] = @"\\location\X2.DTD";
        resolver.DtdFileMap[@"R5.DTD"] = @"\\location\R5.DTD";
        XmlReaderSettings settings = new XmlReaderSettings();
        
        settings.DtdProcessing = DtdProcessing.Parse;
        settings.XmlResolver = resolver;
        XmlReader doc = XmlReader.Create(text, settings);
        
        //perform processing task
        //...
    }
