    Web_Reference_Folder.Lists listService = new Web_Reference_Folder.Lists();
    listService.Credentials= System.Net.CredentialCache.DefaultCredentials;
    
    XmlDocument xmlDoc = new System.Xml.XmlDocument();
    
    XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
    XmlNode ndViewFields = 
        xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
    XmlNode ndQueryOptions = 
        xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");
    
    ndQueryOptions.InnerXml = 
        "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>" + 
        "<DateInUtc>TRUE</DateInUtc>";
    ndViewFields.InnerXml = "<FieldRef Name='Field1' />
        <FieldRef Name='Field2'/>";
    ndQuery.InnerXml = "<Where><And><Gt><FieldRef Name='Field1'/>" + 
        "<Value Type='Number'>5000</Value></Gt><Gt><FieldRef Name='Field2'/>" + 
        "<Value Type=
            'DateTime'>2003-07-03T00:00:00</Value></Gt></And></Where>";
    try
    {
        XmlNode ndListItems = 
            listService.GetListItems("List_Name", null, ndQuery, 
            ndViewFields, null, ndQueryOptions, null);
        MessageBox.Show(ndListItems.OuterXml);
    }
    
    catch (System.Web.Services.Protocols.SoapException ex)
    {
        MessageBox.Show("Message:\n" + ex.Message + "\nDetail:\n" + 
            ex.Detail.InnerText + 
             "\nStackTrace:\n" + ex.StackTrace);
    }
