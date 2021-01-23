    DataTable t = new DataTable();
    //Fill the data table with its columns
    IEnumerable<Task<Result>> results = items.Select(q => AsyncFunction(q.id, t);
    Task<NewResult[]> allTasks = Task.WhenAll(results); //This line is unnecessary with the code available.
    NewResult[] allResults = await results;
    
    using (SqlConnection conn = new SqlConnection(_connString))
    {
        conn.Open();
        using (SqlBulkCopy bc = new SqlBulkCopy(conn))
        {
            bc.BatchSize = 1000;
            bc.DestinationTableName = tableName;
        
            //Joins all of the data rows from all of the generated tables in to a single array.
            DataRow[] allRows = allResults.SelectMany(a=>a.LocalDataTable.AsEnumerable().ToArray();
            bc.WriteToServer(allRows);
        }
    }
    
    
    public async Task<NewResult> AsyncFunction(int id, DataTable template)
    {
        DataTable localDataTable = template.Clone(); //DataTable is thread safe for read operations like .Clone()        
        //Do some stuff
        DataRow dr = t.NewRow();
        dr["ID"] = id
        //Many More columns
        t.Rows.Add(dr);
        //Be sure you have a "await" somewhere in that removed section or else this code will not be multi-threaded.
        return new NewResult("success", localDataTable);    
    }
