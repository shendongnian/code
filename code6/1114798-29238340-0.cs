    XmlSerializer xsSubmit = new XmlSerializer(typeof(Claim));
    
                var subReq = Claim;
                using (StringWriter sww = new Utf8StringWriter())
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                    {
                        Indent = true,
                        OmitXmlDeclaration = false,
                        Encoding = Encoding.Unicode
                    };
    
                    using (XmlWriter writer = XmlWriter.Create(sww, xmlWriterSettings))
                    {
                        xsSubmit.Serialize(writer, subReq);
                        var xml = sww.ToString();
                        PrintOutput(xml);
    
                      
                        File.WriteAllText("out.xml", text);
    
                        Console.WriteLine(xml);
                    }
                }
