     if (@data== null)
     {
        new OleDbParameter("@Dt", SqlDbType.DateTime).Value =DBNull.Value;
     }
    else
    {
        new OleDbParameter(("@Dt", SqlDbType.DateTime).Value = @data;
    }
