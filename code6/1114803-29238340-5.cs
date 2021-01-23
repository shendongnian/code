    DataSet ds = new Dataset();
    DataTable dt = new DataTable();
    ds.Tables.Add(dt);
    System.IO.StringWriter writer = new System.IO.StringWriter();
    Case.WriteXml(writer, XmlWriteMode.WriteSchema);
