    private void FillMyTextbox( )
    {
        // open your database connection
        var sqlLiteConnection = OpenYourConnection( );
 
        using( var sqlLiteCommand = sqlLiteConnection.CreateCommand( ) )
        {
            sqlLiteCommand.CommandText = "select * from abc";
        
            using( var sqlLiteReader = sqlLiteCommand.ExecuteReader( ) )
            {
                while( sqlLiteReader.Read( ) )
                {
                    StringBuilder oneRecord = new 
                    for( int i = 0; i < sqlLiteReader.FieldCount; i++ )
                    {
                        sqlLiteReader[ i ].ToString( );
                    }
                }
            }
        }
    }
