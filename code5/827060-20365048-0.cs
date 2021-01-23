     protected void Page_Load(object sender, EventArgs e)
     {                 
          ReadXmlFile(Server.MapPath("~/XMLFiles/Items.xml"));
     }
            
     private void ReadXmlFile(string fileName)
     {
        string parentElementName = "";
        string childElementName = "";
        string childElementValue = "";
        bool element = false;
        lblMsg.Text = "";
        XmlTextReader xReader = new XmlTextReader(fileName);
        while (xReader.Read())
        {
            if (xReader.NodeType == XmlNodeType.Element)
            {
                if (element)
                {
                    parentElementName = parentElementName + childElementName + "<br>";
                }
                element = true;
                childElementName = xReader.Name;
            }
            else if (xReader.NodeType == XmlNodeType.Text | xReader.NodeType == XmlNodeType.CDATA)
            {
                element = false;
                childElementValue = xReader.Value;
                lblMsg.Text = lblMsg.Text + "<b>" + parentElementName + "<br>" + childElementName + "</b><br>" + childElementValue;
                
                parentElementName = "";
                childElementName = "";
            }
        }
        xReader.Close();
      }
    }
