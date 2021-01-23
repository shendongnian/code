    using System.Xml.Linq;
    
    namespace XMLParser
    {
        class ParseXML
        {
         public void ParseXML(string strXML)
    {
    XDocument xdoc = XDocument.Load(strXML);
    var region= from regions in xdoc.Element("Region");
    
    Region objRegion=new Region();
    Region.Region_Name=region.Element("Region_Name").Value.ToString();
    }
    }
    
    }
