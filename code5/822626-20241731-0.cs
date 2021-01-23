    public class CL_MPG
    {
       private DataTable GetData(DbCommand cmd )
       {   
          // do all the same as you have with exception of your USING DBCOMMAND.
          // just set the connection property of the incoming command to that of
          // your connection created
          // AT THIS PART -- 
          // using (DbCommand cmd = conn.CreateCommand())
          // {
          //    cmd.CommandText = query;
          // just change to below and remove the closing curly bracket for using dbcommand
          cmd.Connection = conn;
       }
    
       // Now, your generic methods that you want to expose for querying
       // something like
       public DataTable GetAllData()
       {
          DbCommand cmd = new DbCommand( "select * from YourTable" );
          return GetData( cmd );
       }
       public DataTable GetUser( int someIDParameter )
       {
          DbCommand cmd = new DbCommand( "select * from YourTable where ID = @parmID" );
          cmd.Parameters.Add( "@parmID", someIDParameter );
          return GetData( cmd );
       }
       public DataTable FindByLastName( string someIDParameter )
       {
          DbCommand cmd = new DbCommand( "select * from YourTable where LastName like @parmTest" );
          cmd.Parameters.Add( "@parmTest", someIDParameter );
          return GetData( cmd );
       }
    }
