    cmd.Connection = conn;
    conn.Open();
    cmd.CommandText = _Query;
    xmlreader = cmd.ExecuteXmlReader();
    // conn.Close();  -- Remove this line and add it at the end
    
    DataSet ds = new DataSet();
    dt.Columns.Add("AcademicYearId", typeof(string));
    dt.Columns.Add("AcademicYearName", typeof(string));
    dt.Columns.Add("StartingYear", typeof(string));
    dt.Columns.Add("EndingYear", typeof(string));
    dt.Columns.Add("Comments", typeof(string));
    dt.Columns.Add("RCO", typeof(string));
    dt.Columns.Add("UserID", typeof(string));
    ds.Tables.Add(dt);
    ds.ReadXml(xmlreader);
    
    conn.Close();
