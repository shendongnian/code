     protected void GetId()
        {
            MSXML2.DOMDocument objXML = new MSXML2.DOMDocument();
            string oPath = null;
            oPath = Server.MapPath("PARNId.xml");
            XmlDocument doc = new XmlDocument();
            if (objXML.load(oPath) == true)
            {
                objNextId = objXML.selectSingleNode("//Id").text;
            }
        }
        protected void SetId()
        {
            MSXML2.DOMDocument objXML = new MSXML2.DOMDocument();
            string oPath = null;
            oPath = Server.MapPath("PARNId.xml");
            XmlDocument doc = new XmlDocument();
            if (objXML.load(oPath) == true)
            {
                objXML.selectSingleNode("//Id").text = objNextId;
            }
            if (RadioButton2.Checked == true)
            {
                Label1.Text = "Your PURCHASE ACTION REQUEST NUMBER Is : PR" + objNextId;
            }
            else
            {
                Label1.Text = "Your PURCHASE ACTION REQUEST NUMBER Is :NP" + objNextId;
            }
            objXML.save(oPath);
        }  
