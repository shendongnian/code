    string cs = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=myhost)(PORT=myport))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=myservicename)));User ID=cat;Password=dog;Persist Security Info=True";
    using (OracleConnection conn = new OracleConnection(cs))
    {
        using (OracleCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "MyPackage.Results";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("start_date", OracleType.DateTime).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters["start_date"].Value = beginning;
            cmd.Parameters.Add("end_date", OracleType.DateTime).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters["end_date"].Value = ending;
            cmd.Parameters.Add("brand", OracleType.Int32).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters["brand"].Value = myBrand;
            cmd.Parameters.Add("summary", OracleType.Cursor).Direction = System.Data.ParameterDirection.Output;
            try
            {
                conn.Open();
                DataTable dt = new DataTable("MyTable");
                OracleDataAdapter a = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet("testDS");
                a.TableMappings.Add("MyTable", "sample_table"); // possible need for this
                a.Fill(ds);
        
                return ds;
            }
            catch 
            {
                return null;
            }
        }
     }
