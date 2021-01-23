    SqlConnection conn = new SqlConnection(ConnectionString);
    
    SqlCommand cmd = new SqlCommand();
    System.Xml.XmlReader xmlreader;
    XmlDataDocument xmlDataDoc = new XmlDataDocument();
    try
    {
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = _Query;
        xmlreader = cmd.ExecuteXmlReader();
        DataSet ds = new DataSet();
        dt.Columns.Add("AcademicYearId", typeof(string));
        dt.Columns.Add("AcademicYearName", typeof(string));
        dt.Columns.Add("StartingYear", typeof(string));
        dt.Columns.Add("EndingYear", typeof(string));
        dt.Columns.Add("Comments", typeof(string));
        dt.Columns.Add("RCO", typeof(string));
        dt.Columns.Add("UserID", typeof(string));
    
        ds.Tables.Add(dt);
        while(xmlreader.Read()
        {
          xmlDataDoc.DataSet.ReadXml(xmlreader);
        }
        ds = xmlDataDoc.DataSet;
        xmlreader.Close();
        conn.Close();
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        if (conn.State != ConnectionState.Closed)
        {
           conn.Close();
        }
    }
