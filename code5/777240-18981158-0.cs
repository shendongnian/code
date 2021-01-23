       {       
         // declarations
         try
         {
            // open connection
            trans = conn.BeginTransaction();
            cmd.Transaction = trans;   // Includes this cmd as part of the trans
            SqlCmd.CommandText = script1;
            SqlCmd.Connection = oConnection;
            var ans = SqlCmd.ExecuteNonQuery();
           if (i == 0) throw new Exception("Failed to save ColumnHeaderSet");
           set.ColSetID = i; //update the object
    
           // Your other queries
           trans.Commit(); // commit transaction
         }
         catch (Exception e){
            trans.Rollback();
            throw e;
         }
         finally{
            conn.Close();
       }
