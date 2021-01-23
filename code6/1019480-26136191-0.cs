    private void GetXMLData()
    {
        try
        {
            xmlTitle.Text = "";
            XNamespace ns = "http://www.ibm.com/software/analytics/spss/xml/oms";
            XDocument testXML = XDocument.Load(@"C:\Users\by\Desktop\SITE\ori.xml");
    
            var cats = from cat in testXML.Element(ns + "outputTree")
                           .Elements(ns + "command")
                           .Elements(ns + "pivotTable")
                           .Elements(ns + "dimension")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "group")
                           .Elements(ns + "category")
                           select new
                           {
                               parentC = cat.Parent.Attribute("number").Value,
                               id = cat.Attribute("number").Value,                            
                           };
    
            foreach (var cat in cats)
            {
                xmlTitle.Text += "</br>Parent: " + cat.parentC + " and ";
                xmlTitle.Text += "Cat: " + cat.id + " </br>";
            }
    
    
        }
        catch (Exception err)
        {
            throw (err);
        }
    }
