            public static void GetPaths()
        {
            //substitute DB.GetSqlConnection() for your way of getting your connection
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"GetFilePaths"
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    //Declare the output parameters you're gonna use in your stored procedure
                    SqlParameter oldFile_param = new SqlParameter("OldFile", System.Data.SqlDbType.NVarChar, 1000);
                    oldFile_param.Direction = System.Data.ParameterDirection.Output;
                    SqlParameter newFile_param= new SqlParameter("NewFile", System.Data.SqlDbType.NVarChar, 1000);
                    newFile_param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(oldFile_param);
                    cmd.Parameters.Add(newFile_param);
                    cmd.ExecuteNonQuery();
                    object oldFile = oldFile_param.Value;
                    object newFile = newFile_param.Value;
                }
            }
        }
