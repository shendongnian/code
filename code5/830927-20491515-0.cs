    using( DataAccessAdapter adapter = new DataAccessAdapter() )
    {
    	IDataReader reader = adapter.FetchDataReader( 
    		RetrievalProcedures.GetCustOrdersOrdersCallAsQuery( "CHOPS" ), 
    		CommandBehavior.CloseConnection );
    	while( reader.Read() )
    	{
    		Console.WriteLine( "Row: {0} | {1} | {2} | {3} |", reader.GetValue( 0 ), 
    			reader.GetValue( 1 ), reader.GetValue( 2 ), reader.GetValue( 3 ) );
    	}
    	// close reader, will also close connection
    	reader.Close();
    }
