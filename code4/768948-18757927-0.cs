    var xml = System.Xml.Linq.XDocument.Load(@"D:\test.xml");
    
    var myNamespace = "http://schemas.microsoft.com/office/infopath/2003/myXSD/2013-01-09T15:23:27";
    var htmlNamespace = "http://www.w3.org/1999/xhtml";
    
    var myFields = xml.Element(System.Xml.Linq.XName.Get("myFields", myNamespace));
    var projectDescription = myFields.Element(System.Xml.Linq.XName.Get("ProjectDescription", myNamespace));
    var htmlTag = projectDescription.Element(System.Xml.Linq.XName.Get("html", htmlNamespace));
    var pTag = htmlTag.Element(System.Xml.Linq.XName.Get("p", htmlNamespace));
    
    var pValue = pTag.Value;
