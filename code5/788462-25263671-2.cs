            using (OracleConnection objConn = new OracleConnection(connStr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "Oracle_PkrName.Stored_Proc_Name";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("Emp_id", OracleType.Int32).Value = 3; // Input id
                objCmd.Parameters.Add("Emp_out", OracleType.Cursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);                   
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Exception: {0}", ex.ToString());
                }
                objConn.Close();
            }
