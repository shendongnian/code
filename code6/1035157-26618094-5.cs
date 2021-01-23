    int _Height = -1;
    int _Width = -1;
    
    SqlConnection _Connection = new SqlConnection("connect string");
    SqlCommand _Command = new SqlCommand("uspRetMostCommonScreenRes", _Connection);
    _Command.CommandType = CommandType.StoredProcedure;
    
    _SqlParameter _WidthParam = new SqlParameter("@Width", SqlDbType.Int);
    _WidthParam.Direction = ParameterDirection.Output;
    _Command.Parameters.Add(_WidthParam);
    _SqlParameter _HeightParam = new SqlParameter("@Height", SqlDbType.Int);
    _HeightParam.Direction = ParameterDirection.Output;
    _Command.Parameters.Add(_HeightParam);
    try
    {
      _Connection.Open();
    
      _Command.ExecuteNonQuery();
    
      _Width = (int)_WidthParam.Value;
      _Height = (int)_HeightParam.Value;
    }
    finally
    {
      _Connection.Close();
    }
