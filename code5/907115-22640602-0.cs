    DataSet ds = new DataSet();
    DataTable table = ds.Tables.Add("Example");
    table.Columns.Add("BoolArray", typeof(bool[]));
    
    table.Rows.Add(new object[] { new bool[]{true, false} });
    table.Rows.Add(new object[] { new bool[] { false, false } });
    
    StringWriter dataWriter = new StringWriter();
    StringWriter schemaWriter = new StringWriter();
    table.WriteXmlSchema(schemaWriter);
    table.WriteXml(dataWriter, XmlWriteMode.IgnoreSchema);
    Console.WriteLine(schemaWriter.ToString());
