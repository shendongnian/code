         private void InsertFoo(SqlTransaction txn, string fooName)
         {
             using (var cmd = txn.Connection.CreateCommand())
             {
                 try
    		     {
    			     do your process here...
    			     cmd.Commit();
    		     }
    		     catch(Exception ex)
    		     {
    			    cmd.Rollback();
    		     }
             }
         }
