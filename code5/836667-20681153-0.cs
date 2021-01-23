    protected static bool TestaIntegracaoErpMigplus()
    {
        string connectionStringMigplus = WebConfigurationManager.ConnectionStrings["ConnectionStringMigplus"].ConnectionString;
        var task = Task.Factory.StartNew<bool>(()=>{
            bool ret = true;
            using (SqlConnection Conn = new SqlConnection(connectionStringMigplus))
            {
                try
                {
                    Conn.Open();
                }
                catch (SqlException)
                {
                    ret = false;
                }
            }
            return ret;
        });
        if(task.Wait(/*your timeout in milliseconds*/)){
            return task.Result;
        }
        
        return false;
    }
