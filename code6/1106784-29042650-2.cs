       using (IfxTransaction tran = conn.BeginTransaction())
       {
          try
          {
             // All db operations here
             tran.Commit();
          }
          catch(Exception e)
          {
             tran.Rollback();
             throw; // Or return error code
          }
       }
