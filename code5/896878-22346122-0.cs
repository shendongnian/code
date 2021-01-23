    using (OleDbConnection con = ConnectionProvider.CreateConnection())
    {
        con.Open();
        OleDbTransaction trans = con.BeginTransaction ();
        OleDbCommand cmd = new OleDbCommand(...);
        //....
        OleDbParameter blob = new OleDbParameter();
        blob.OleDbType = OleDbType.LongVarBinary;
        blob.Value = /// a byte[]
        cmd.Parameters.Add(blob);
        cmd.ExecuteNonQuery();
        trans.Commit();
    }
