    public class MyDBHandler
    {
       public virtual IDbConnection GetConnection()
       {  throw new Exception( "Please define specific GetConnection method"}; }
    
       public virtual IDbCommand GetCommand()
       {  throw new Exception( "Please define specific GetCommand method"}; }
    
       public virtual IDbDataAdapter GetDataAdapter()
       {  throw new Exception( "Please define specific DataAdapter method"}; }
    
       public virtual string GetConnectionString()
       {  throw new Exception( "Please define specific ConnectionString method"}; }
     
    
       etc...
    
       // Then some common properties you might want for connection path, server, user, pwd
       protected string whatServer;
       protected string whatPath;
       protected string whatUser;
       protected string whatPwd;
    
    
       protected connectionHandle;
    
       public MyDBHandler()
       {
          // always start with HAVING a connection object, regardless of actual connection or not.
          connectionHandle = GetConnection();
       }
       // common function to try opening corresponding connection regardless of which server type
       public bool TryConnect()
       {
          if( connectionHandle.State != System.Data.ConnectionState.Open )
             try
             {
                connectionHandle.ConnectionString = GetConnectionString();
                connectionHandle.Open();
             }
             catch( Exception ex )
             {
                // notify user or other handling 
             }
    
          if( connectionHandle.State != System.Data.ConnectionState.Open )
             MessageBox.Show( "Some message to user." );
    
          // return true only if state is open
          return connectionHandle.State == System.Data.ConnectionState.Open;
       }
    
       // Now, similar to try executing a command as long as it is of IDbCommand interface to work with
       public bool TryExec( IDbCommand whatCmd, DataTable putResultsHere )
       {
          // if can't connect, get out
          if( ! TryConnect() )
             return false;
    
          bool sqlCallOk = false;
    
          if( putResultsHere == null ) 
             putResultsHere = new DataTable();
    
          try
          {
             da.Fill(oTblResults, putResultsHere);
    
             // we got this far without problem, it was ok, regardless of actually returning valid data
             sqlCallOk = true;
          }
          catch( Exception ex )
          {
             // Notify user of error
          }
    
          return sqlCallOk;
       }
    
    
    }
    
    public class SQLHandler : MyDbHandler
    {
       public override IDbConnection GetConnection()
       {  return (IDbConnection) new SqlConnection(); }
    
       public override IDbCommand GetCommand()
       {  return (IDbCommand) new SqlCommand("", connectionHandle ); }
    
       public override IDbDataAdapter GetDataAdapter()
       {  return (IDbDataAdapter) new SqlDataAdapter(); }
    
       public override string GetConnectionString()
       {  return "Driver={SQL Server}; blah, blah of properties"; }
    
    }
    
    public class MySQLHandler : MyDbHandler
    {
       public override IDbConnection GetConnection()
       {  return (IDbConnection) new MySqlConnection(); }
    
       public override IDbCommand GetCommand()
       {  return (IDbCommand) new MySqlCommand("", connectionHandle ); }
    
       public override IDbDataAdapter GetDataAdapter()
       {  return (IDbDataAdapter) new MySqlDataAdapter(); }
    
       public override string GetConnectionString()
       {  return "Driver={MySql}; blah, blah of properties"; }
    }
