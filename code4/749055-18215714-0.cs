    protected void BindDataToGridviewDropdownlist()
    {
        XmlTextReader xmlreader = new XmlTextReader(Server.MapPath("XMLFILE.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(xmlreader);
        xmlreader.Close();
            
        if (ds.Tables.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlDetails.Items.Add(new ListItem(dr["name"].ToString() + " - " + dr["img"].ToString(), dr["name"].ToString()));
            }
        }
    
    }
