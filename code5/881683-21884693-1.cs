    void HandleSqlException(SqlException e)
    {
         if (sqlex.Procedure == "myTrigger" || sqlex.Message.Contains("myTrigger"))
         {
            // act
         }        
    }
    ...
    try
    {
        entities.SaveChanges();
    } 
    catch (System.Data.DataException dex)
    {
        if (dex.InnerException is SqlException)
           HandleSqlException((SqlException)dex);
    }
    catch (SqlException sqlex)
    {
        HandleSqlException(sqlex);
    } 
    catch (Exception e) 
    {
        // non-SQL exception handling
    }
