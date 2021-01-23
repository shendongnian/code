    AseBulkCopy obj_AseBulkCopy = new AseBulkCopy(db_Conn);
    obj_AseBulkCopy.DestinationTableName = "db_Table";
    obj_AseBulkCopy.BatchSize = 1000;
    db_Conn.Open();
    obj_AseBulkCopy.WriteToServer(dt_DataTable);
    db_Conn.Close();
