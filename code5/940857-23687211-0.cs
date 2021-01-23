    public void HelpMeTest() {
            string odbcConnectionString = string.Format("DSN={0};UID={1};PWD={2};", "MY-DNS", "myUser", "pwd");
            string db2ConnectionString = "Database=myDataBase;";
    
            using (DB2Connection db2Con = new DB2Connection(db2ConnectionString))
    		{
                db2Con.Open();
                db2Con.Close();
    		}
            
    		using (OdbcConnection odbcCon = new OdbcConnection(odbcConnectionString))
    		{
                odbcCon.Open();
                odbcCon.Close();
    		}
        }
