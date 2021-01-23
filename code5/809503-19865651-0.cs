        [HttpPost]
        public JsonResult Edit(string Data)
        {
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        var formData = js.Deserialize<object>(Data) as IDictionary<string, object>;
        List<SqlDataRecord> sqlDataRecords = new List<SqlDataRecord>(); 
        foreach (var item in formData)
        {
            // Create sql data record with appropriate properties populated and add to list if applicable
        }
        SqlParameter[] sqlParameters = new SqlParameter("YourTableTypeParamName", SqlDbType.Structured)
							{
								Value = sqlDataRecords,
								TypeName = "dbo.YourTableType"
							};
            SqlConnection conn = ... // define connection here
            try
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.Connection = conn;
                    conn.Open();
                    command.CommandText = "YourStoredProcedureName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        // Do something with results
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        return null;
    }
