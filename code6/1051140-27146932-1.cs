    public List<OracleParameter> ToOracleParameters()
    {
    	return new List<OracleParameter>
    	{
    		new OracleParameter("My_Date_Time", OracleDbType.Date, MyDateTime, ParameterDirection.Input),
    		new OracleParameter("Source", OracleDbType.VarChar, Source, ParameterDirection.Input),
    		new OracleParameter("ID", OracleDbType.Number, ParameterDirection.Output)
    	};
    }
