        /****** Object:  Table [dbo].[Table_1]    Script Date: 10/24/2014 12:07:42 PM ******/
    SET ANSI_NULLS ON
    GO
    
    SET QUOTED_IDENTIFIER ON
    GO
    
    CREATE TABLE [dbo].[Table_1](
    	[id] [int] NULL,
    	[GuidTest] [uniqueidentifier] NULL,
    	[GuidTest2] [uniqueidentifier] NULL,
    	[GuidTest3] [uniqueidentifier] NULL
    ) ON [PRIMARY]
  
      /****** Object:  StoredProcedure [dbo].[Test_RollBack]    Script Date: 10/24/2014 12:08:04 PM ******/
    
    /****** Object:  StoredProcedure [dbo].[Test_RollBack]    Script Date: 10/24/2014 12:08:04 PM ******/
    SET ANSI_NULLS ON
    GO
    
    SET QUOTED_IDENTIFIER ON
    GO
    
    
    CREATE PROCEDURE [dbo].[Test_RollBack]	
    AS
    BEGIN
    	DECLARE @counter int = 1
    
    	while @counter < 3000000
    	BEGIN
    		INSERT INTO Table_1(id, GuidTest, GuidTest2, GuidTest3)
    		VALUES(@counter, newId(), newId(), newId())
    		set @counter = @counter + 1
    	END
    
    
    	update Table_1
    	SET	GuidTest = newid()
    END
    
    GO
    [TestMethod()]
        public void RollBackTestTimeout()
        {
            using (SqlConnection conn = new SqlConnection("Your ConnectionString"))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            
                            cmd.Connection = conn;
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Test_RollBack";
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                
            }
        }
        [TestMethod()]
        public void RollBackTestTimeout_WithUsing()
        {
            using (SqlConnection conn = new SqlConnection("Your ConnectionString"))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Test_RollBack";
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                }
            }
        }
