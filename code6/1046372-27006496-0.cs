    var @ThisBatch2 = new System.Data.SqlClient.SqlParameter("ThisBatch2", System.Data.SqlDbType.VarChar, 3, "Batch_ID");
    @ThisBatch2.Value = Session["ThisBatch"];
    
    sql = "";
    sql = "UPDATE dbo.BactiBucket SET RecvDate = GetDate() WHERE Batch_ID= @ThisBatch2";
    
    _db.ExecuteStoreCommand(sql, ThisBatch);
