    protected void DoStreamingInsert()
    {
        var rowList = new List<TableDataInsertAllRequest.RowsData>();
        var row1 = new TableDataInsertAllRequest.RowsData();
        var row2 = new TableDataInsertAllRequest.RowsData();
        row1.Json = new Dictionary<string, object>();
        row1.Json.Add("TextField", "SomeTest");
        row1.Json.Add("DataField", "2014-10-31 00:00:00.0000");
        //row1.InsertId = DateTime.Now.Ticks.ToString();    Give this ID to prevent duplicate insert
        row2.Json = new Dictionary<string, object>();
        row2.Json.Add("TextField", "SomeTest1");
        row2.Json.Add("DataField", "2014-11-30 00:00:00.0000");
        rowList.Add(row1);
        rowList.Add(row2);
        var content = new TableDataInsertAllRequest();
        content.Rows = rowList;
        content.Kind = "bigquery#tableDataInsertAllRequest";
        content.IgnoreUnknownValues = true;
        content.SkipInvalidRows = true;
        var insertTask = BQDefs.BQService.Tabledata.InsertAll(content,
                BQDefs.ProjectID, BQDefs.DataSet, BQDefs.TableName);
                
        TableDataInsertAllResponse response = insertTask.Execute();
    }
