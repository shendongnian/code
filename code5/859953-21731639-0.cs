        MTTS = GetMTTS(JOB_PLAN, JOB_NAME,JOB_NAME_ID,RUN_ID,JOB_STATUS);
    
        public DateTime GetMTTS(string JOB_PLAN, string JOB_NAME, string JOB_NAME_ID, Decimal RUN_ID, string JOB_STATUS){
            string myEnvName = XXX;
            TableName = XXX.ToString();
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[myEnvName].ToString();
            string thisRUN_ID = RUN_ID.ToString();
            cmdText = @"SELECT MTTS FROM " + TableName + 
                " WHERE JOB_PLAN = '" + JOB_PLAN + "'"
                + " AND JOB_NAME = '" + JOB_NAME + "'"
                + " AND JOB_NAME_ID = '" + JOB_NAME_ID + "'"
                + " AND RUN_ID = '" + thisRUN_ID + "'"
                + " AND JOB_STATUS = '" + JOB_STATUS + "'";
            
            DataSet ds = new DataSet();           
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand SQLcc = new SqlCommand(cmdText,conn);
                    SqlDataReader reader;
                    reader = SQLcc.ExecuteReader();
                    while (reader.Read())
                    {
                        MTTS = reader.GetDateTime(0);
                    }        
                    reader.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }                
            }
            return MTTS;
        }
