    public int GetMySequence()
    {
       SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
       {
          Direction = System.Data.ParameterDirection.Output
       };
                
       Database.ExecuteSqlCommand(
                  "SELECT @result = (NEXT VALUE FOR MySequence)", result);
    
       return (int)result.Value;
    }
