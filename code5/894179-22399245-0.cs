    public class OracleOperations
    {
	OracleConnection oraConn = new OracleConnection();
  
	private bool connStatus;
	public OracleOperations()
	{
		connStatus = false;
		connect();
	}
	~OracleOperations()
	{
		disconnect();
	}
	public bool getConnStatus()
	{
		return connStatus;
	}
	public void connect()
	{
		string connString = "User Id=xxxx; Password=yyyyy; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.10.10)(PORT=1583))(CONNECT_DATA=(SERVER=dedicated)(SID=oracledb)))";
		if (oraConn.State != ConnectionState.Open)
		{
			try
			{
				oraConn.ConnectionString = connString;
				oraConn.Open();
				Console.WriteLine("Successful Connection");
				connStatus = true;
			}
			catch (Exception eOra)
			{
				Console.WriteLine(eOra.Message+ "Exception Caught");
				connStatus = false;
				throw eOra;
			}
		} 
	}
	public void disconnect()
	{
		if (oraConn.State == ConnectionState.Open)
		{
			try
			{
				oraConn.Close();
				connStatus = false;
				Console.WriteLine("Connection Closed");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "Exception Caught");
			}
		}
	}
    }
