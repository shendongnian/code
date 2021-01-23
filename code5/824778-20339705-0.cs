    var ds = new DataSet("MyDataSet");
    var dt = ds.Tables.Add("MyDataTable");
    dt.Columns.Add("MyDateTime", typeof (DateTime));
            
    var startingDateTime = DateTime.Now;
    dt.Rows.Add(startingDateTime);
            
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
        ds.WriteXml(writer, XmlWriteMode.WriteSchema);
    Debug.WriteLine(sb.ToString());
    var ds2 = new DataSet();
    using (var reader = new StringReader(sb.ToString()))
        ds2.ReadXml(reader, XmlReadMode.ReadSchema);
    var resultingDateTime = (DateTime) ds2.Tables[0].Rows[0]["MyDateTime"];
    Debug.WriteLine("");
    Debug.WriteLine("Starting: {0} ({1})", startingDateTime, startingDateTime.Kind);
    Debug.WriteLine("Ending:   {0} ({1})", resultingDateTime, resultingDateTime.Kind);
