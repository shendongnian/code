    public void ImportToSql(string file path, string connectionStr)
    {
      var dt = new DataTable("TableName");
      dt.Columns.Add("Column1", typeof(string)).AllowDBNull = true;
      dt.Columns.Add("Column2", typeof(string)).AllowDBNull = true;
      using(var reader = new StreamReader(FilePath))
    {
    while(!reader.EndOfStream)
    {
      string line = reader.ReadLine();
      if(String.IsNullOrEmpty(line))Continue;
      string field1 = line.substring(0,9);
      string field2 = line.substring(9,9);
      var row = dt.NewRow();
      row["Column1"] = field1.Trim();
      row["Column2"] = field2.Trim();
      dt.Rows.Add(row);
    }
    using(var conn = new sqlconnection(connectionStr)
    {
      connectionStr.Open();
      using(var blkCopy = new SqlBulkCooy(connectionStr)
    {
      blkcopy.DestinationTableName = "Table1";
      blkcopy.WriteToServer(dt);
    }
    }
    }
    }
