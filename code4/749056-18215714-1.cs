    protected void BindDataToGridviewDropdownlist()
    {
        XmlTextReader xmlreader = new XmlTextReader(Server.MapPath("xml/XMLFILE.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(xmlreader);
        xmlreader.Close();
            
        if (ds.Tables.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                li.Attributes.Add("data-image", dr["img"].ToString());
                ddlDetails.Items.Add(li);
            }
        }
    
    }
