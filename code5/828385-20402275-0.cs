    using (IDbTransaction tran = conn.BeginTransaction()) {
        try {
    
            ...Delete File From DB Code...  // statement 2
            MyClass.DeleteFile(fileId);             // statement 1
           
            tran.Commit();
        }  catch {
            tran.Rollback();
            throw;
        }
    }
