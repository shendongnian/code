    private void DbInsertTestTable()
    {
    
        string User = System.Web.HttpContext.Current.User.Identity.Name.ToString();
        string ServName = "";
        string SqlStatement = "INSERT INTO [myDB].[dbo].[mytable] ([AppCounterData],[User],[DateTime],[ServName]) VALUES (@COLUMN1,@COLUMN2,@COLUMN3,@@ServerName);";
    
        using (SqlConnection c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["webconfconstringname"].ConnectionString))
        {
            SqlCommand cmd = SqlCmdQuery(c, SqlStatement);
            cmd.Parameters.AddWithValue("@COLUMN1", AppCounter);
            cmd.Parameters.AddWithValue("@COLUMN2", User);
            cmd.Parameters.AddWithValue("@COLUMN3", DateTime.Now);
            cmd.Parameters.AddWithValue("@COLUMN4", ServName);
            SqlCmdOpExCl(c, cmd);
        }
    }
    
      
    private void SqlInsertFirstAttempt()
    {
        try
        {
            DbInsertTestTable();
        }
        catch (SqlException sqlEx)
        {
            DoWithRetry(DbInsertTestTable, TimeSpan.FromSeconds(1), retryCount: 30);
        }           
     }
