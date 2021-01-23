    try
    {
        using (var db1 = new SqlConnection(connectionString1))
        {
            // use the resource
        }
    
        using (var db2 = new SqlConnection(connectionString2))
        {
            // use the resource
        }
    
        // you can use other resources...
    
        // Don't forget this
        t.Complete();
    }
    catch (Exception ex)
    {
        // handle the error. No need to rollback
    }
    }
