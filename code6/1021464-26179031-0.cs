     DbCommand Cmd = null;
      using (DataClient client = new DataClient())
      {
     SqlParameter[] parameters = new SqlParameter[2];
     parameters[0] = new SqlParameter("@ID", SqlDbType.VarChar);
     parameters[0].Size = 10;
     parameters[0].Direction = ParameterDirection.Output;
     parameters[1] = new SqlParameter("@YourParameterName", SqlDbType.VarChar);
     parameters[1].Value = Class.PropertyName;
     parameters[2] = new SqlParameter("@Year", SqlDbType.Int);
     client.ExecuteNonQuery("ReturnCommandForSp_ReturnSingleGame", CommandType.StoredProcedure, parameters, ref Cmd);
     Then retrieve it like this
     int yourReturnValue= Convert.ToInt32(Cmd.Parameters["@ID"].Value);
     }
