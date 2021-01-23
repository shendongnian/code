    XDocument doc=XDocument.Parse(xmlstr);
    var result=doc.Descendants().Elements("UnitTestResult")
                       .Where(x=>x.Attribute("outcome")=="Failed")
                       .Select(x=>
                        new
                        {
                             Message=x.Element("Output")
                                      .Element("ErrorInfo")
                                      .Element("Message").Value,
                             StackTrace=x.Element("Output")
                                         .Element("ErrorInfo")
                                         .Element("StackTrace").Value
                        });
