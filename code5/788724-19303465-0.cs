    public class SQLServer
	{   
		SqlConnection myConnection = null;
		SqlCommand myCommand = null;
		/// <summary>
		/// Connection information should be stored in the appp.conf
		/// Example:
		/// <add name="SQLConnection" connectionString="Data Source=server;Initial Catalog=YourDatabase;
		///   Integrated Security="True" providerName="System.Data.SqlClient"/>
		/// </summary>
		public SQLServer()
		{
		  string myConfig = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
		  myConnection = new SqlConnection(myConfig);
		  myConnection.Open();
		}
        //Executes sql query and returns datareader		
        public SqlDataReader NewReader(string sSQL)
		{
		  myCommand = new SqlCommand(sSQL, myConnection);
		  SqlDataReader myReader = myCommand.ExecuteReader();
		  return myReader;
		}
                
        //Execute sql statement and returns nothing usefull for inserts and updates
		public void Execute(string SQL)
		{
		  Execute(SQL, false);
		}
     }
