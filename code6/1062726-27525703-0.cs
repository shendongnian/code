    class MyDataRow
    {
        public int Id {get;set;}
        public double FieldB {get;set;}
        public string FieldC {get;set;}
    }
    string queryText = @"
    SELECT 
        t1.Id, 
        t1.FieldB, 
        (SELECT hashTag FROM table_2 WHERE contactId = t1.Id) AS FieldC
    FROM table_1 AS t1
    ";
    
    // EF will map properties automatically and you do not have to write and configure stored procedure...
    List<MyDataRow> rows = context.ExecuteStoreQuery<MyDataRow>(queryText).ToList();
