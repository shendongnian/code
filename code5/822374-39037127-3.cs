    //Get Column from Source table 
    string sourceTableQuery = "Select top 1 * from sourceTable";
    // i use sql helper for executing query you can use corde sw
    DataTable dtSource 
        = SQLHelper.SqlHelper
            .ExecuteDataset(transaction, CommandType.Text, sourceTableQuery)
            .Tables[0];
     
    for (int i = 0; i < destinationTable.Columns.Count; i++)
    {
        string destinationColumnName = destinationTable.Columns[i].ToString();
        // check if destination column exists in source table 
        // Contains method is not case sensitive    
        if (dtSource.Columns.Contains(destinationColumnName))
        {
            //Once column matched get its index
            int sourceColumnIndex = dtSource.Columns.IndexOf(destinationColumnName);
            string sourceColumnName = dtSource.Columns[sourceColumnIndex].ToString();
            // give column name of source table rather then destination table 
            // so that it would avoid case sensitivity
            bulkCopy.ColumnMappings.Add(sourceColumnName, sourceColumnName);
        }                               
    }
    bulkCopy.WriteToServer(destinationTable);
    bulkCopy.Close();
        
