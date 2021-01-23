    using System.Data;
    using System.Xml.Xsl;
    XslTransform transform = new XslTransform();
    transform.Load(@"Transform.xsl");
    transform.Transform(@"Example.xml", @"TransformedExample.xml");
    
    DataSet data = new DataSet();
    data.ReadXml(@"TransformedExample.xml");
