    DataTable dt = new DataTable();
    dt.TableName = "Sample";
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    dt.Columns.Add("Column3");
    dt.Columns.Add("Column4");
    dt.WriteXmlSchema(@"D:Project1\example.xsd");
