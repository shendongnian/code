    private void ConvertXMLToDT(string myXML)
    {
        //XmlDocument xmlDocs = new XmlDocument();
        //xmlDocs.LoadXml(myXML);
        DataSet ds = new DataSet();
        //ds.ReadXml(xmlDocs);   //--->this statement doesn't work
        ds.ReadXml(XmlReader.Create(new StringReader(myXML)));
        DataTable dtFormats = ds.Tables[0];
        DataTable dtPreset1 = ds.Tables[1];        
        Response.Write("done");
    }
