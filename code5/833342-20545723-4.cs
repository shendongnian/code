    public int GetRowSize(OracleCommand cmd)
    {
       OracleDataReader dr = cmd.ExecuteReader();
       return (int)( dr.GetType().GetField("m_rowSize", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dr) );
    }
