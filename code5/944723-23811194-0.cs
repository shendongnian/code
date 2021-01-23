    bool blnAbsent = true;
    string strClientNumber = "";
    foreach (SPListItem item in varCustomerNumbers)
    {
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(item["CustomerNumbers"].ToString());
        XmlNodeList nodelist = xml.GetElementsByTagName("user");
        foreach (XmlNode varUser in nodelist)
        {
            if (clientnumber == varUser.InnerText)
            {
                blnAbsent = false;
                this.Controls.Add(new LiteralControl("   <tr><td>" + varUser.InnerText + "</td><td><input name=\"\" type=\"checkbox\"\n"));
                if (varUser.Attributes["parent"].InnerText == "true")
                    this.Controls.Add(new LiteralControl(" checked\n"));
                this.Controls.Add(new LiteralControl("/></td><td><input name=\"\" type=\"checkbox\"\n"));
                if (varUser.Attributes["national"].InnerText == "true")
                    this.Controls.Add(new LiteralControl(" checked\n"));
                this.Controls.Add(new LiteralControl("/></td></tr>\n"));
            }
        }
    }
    
    if (blnAbsent == true)
    {
        this.Controls.Add(new LiteralControl("   <tr><td>" + clientnumber + "</td><td><input name=\"\" type=\"checkbox\" /></td><td><input name=\"\" type=\"checkbox\" /></td></tr>\"\n"));
    }
