    private MySQLConnector _MySQL = null;
    protected MySQLConnector MySQL
    {
       get
       {
          if (_MySQL == null)
          {
             _MySQL = new MySQLConnector();
          }
          return _MySQL;
       }
    }
    
    public void Update(int programId, int LocationId, string Name, string modifiedBy)
       {
       List<MySqlParameter> parameterList = new List<MySqlParameter>();
    
       parameterList.Add(new MySqlParameter("ProgramID", programId));
       parameterList.Add(new MySqlParameter("LocationId", LocationId));
       parameterList.Add(new MySqlParameter("Name", Name));
       if (!string.IsNullOrEmpty(modifiedBy))
       {
          parameterList.Add(new MySqlParameter("ModifiedBy", modifiedBy));
       }
       else
       {
          parameterList.Add(new MySqlParameter("ModifiedBy", DBNull.Value));
       }
    
       const string TheSql = @"
                UPDATE ProgramLocation
                SET
    	       Name = @Name,
                   ModifiedOn = GETDATE(),
                   ModifiedBy = @ModifiedBy
                WHERE
    		ProgramID = @ProgramID
    		AND LocationId = @LocationId";
    
       MySQL.ExecuteNonQuerySql(TheSql, parameterList);
    }
