    string xml="xml"; 
    XDocument doc = XDocument.Parse(xml);
     XNamespace bodyNameSpace ="http://schemas.xmlsoap.org/soap/envelope/";
     var bodyXml = from _e in doc.Descendants(bodyNameSpace + "Body")
                              select _e;
     if (bodyXml.Elements().Count() == 0)
                {
                    return;
                }
    var email = from _e in bodyXml.First()Descendants("Email")
                                          select _e;
    if(email.Count()==1)
    {
    	string emailAddress=email.First().Value;
    }
