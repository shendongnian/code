    public bool GenericSP_PersistentConnection(string strStoredProcedureName, SortedList<string, string> values, SqlConnection s_persistent_conn, SqlTransaction transaction, string returnValueName)
    {
        try
        {
            if (strStoredProcedureName == "") throw new Exception(noStoredProcedure);
            if (values == null) throw new Exception(noValue);
            if (returnValueName == "") throw new Exception(noOutputParameterName);
            //If Connection object is null, create a new on
            if (s_persistent_conn == null) s_persistent_conn = new SqlConnection(GetConnectionString());
            //Create command object
            s_comm = new SqlCommand(strStoredProcedureName, s_persistent_conn);
            s_comm.CommandType = CommandType.StoredProcedure;
            s_comm.Transaction = transaction;
            s_comm.CommandTimeout = 600;
            s_adap = new SqlDataAdapter(s_comm);
            ////set up the parameters for the stored proc
            foreach (var item in values)
                s_comm.Parameters.AddWithValue("@" + item.Key, item.Value);
            s_comm.Parameters.AddWithValue("@" + returnValueName, 0);
            s_comm.Parameters["@" + returnValueName].Direction = ParameterDirection.Output;
            //Excecute call to DB
            s_comm.ExecuteNonQuery();
            outputValue = s_comm.Parameters["@" + returnValueName].Value.ToString();
            }
        catch (Exception ex)
        {
            // If something happens, rollback the whole transaction.
            transaction.Rollback();
            throw ex;
        }
        finally
        {
                s_comm.Dispose();
                s_adap.Dispose();
        }
        return true;
    }
