    var bpsResponseXml = new XElement("BPSResponse");         
    
    bpsResponseXml.Add(new XElement("Response",
                                        new XElement("Code", "804"),
                                        new XElement("Text", "TagID value is not genuine")));
    
    var outPutXml = bpsResponseXml.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
