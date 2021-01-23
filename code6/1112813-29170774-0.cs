    using System.XML.Linq;
    
    class XMLParseProgram
    {
    public DataTable ReadXML(string strXML)
    {
      XDocument xdoc = XDocument.Load(strXML);
    
      var property= from props in xdoc.Element("Solution").Elements("Property").ToList().ToList();
    
    if (property!= null)
                {
    
                    DataTable dtItem = new DataTable();
                    dtItem.Columns.Add("Name");
                    dtItem.Columns.Add("Value");
    
    foreach (var itemDetail in property.ElementAt(0))
                    {
                        dtItem.Rows.Add();
    
                        if (itemDetail.Descendants("Name").Any())
                            dtItem.Rows[count]["Name"] = itemDetail.Element("Name").Value.ToString();
    
                        if (itemDetail.Descendants("Value").Any())
                            dtItem.Rows[count]["Value"] = itemDetail.Element("Value").Value.ToString();
    }
    }
    }
    
    }
