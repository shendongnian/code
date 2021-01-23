    int _Height = -1;
    int _Width = -1;
    
    SqlConnection _Connection = new SqlConnection("connect string");
    SqlCommand _Command = new SqlCommand("uspRetMostCommonScreenRes", _Connection);
    _Command.CommandType = CommandType.StoredProcedure;
    
    _set output params -- coming soon ;-) _
    try
    {
      _Connection.Open();
    
      _Command.ExecuteNonQuery();
    
      _get output params_
    }
    finally
    {
      _Connection.Close();
    }
