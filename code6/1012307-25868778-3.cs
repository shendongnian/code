    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    dt.Columns.Add("AcademicYearId", typeof(string));
    dt.Columns.Add("AcademicYearName", typeof(string));
    dt.Columns.Add("StartingYear", typeof(string));
    dt.Columns.Add("EndingYear", typeof(string));
    dt.Columns.Add("Comments", typeof(string));
    dt.Columns.Add("RCO", typeof(string));
    dt.Columns.Add("UserID", typeof(string));
    ds.Tables.Add(dt);
    cmd.Connection = conn;
    conn.Open();
    cmd.CommandText = _Query;
    xmlreader.Read();    -- // Add this line
    xmlreader = cmd.ExecuteXmlReader();
    // conn.Close();  -- Remove this line and add it at the end   
    ds.ReadXml(xmlreader);
    conn.Close();
