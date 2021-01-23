    XDocument doc=XDocument.Load(url);
    var output= doc.Elements("property").Select(x=>
                  new
                  {
                        empid=x.Element("empid").Value,
                        empname=x.Element("empname").Value,
                        project=x.Element("project").Value
                  }
    );
