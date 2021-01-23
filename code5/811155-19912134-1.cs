    private void FillMyTextbox( )
    {
        // open your database connection
        var sqlLiteConnection = OpenYourConnection( );
 
        // create command
        using( var sqlLiteCommand = sqlLiteConnection.CreateCommand( ) )
        {
            sqlLiteCommand.CommandText = "select * from abc";
        
            // create the reader
            using( var sqlLiteReader = sqlLiteCommand.ExecuteReader( ) )
            {
                // a StringBuilder to store the contents of your table 
                var allRecords = new StringBuilder( );
                while( sqlLiteReader.Read( ) )
                {
                    for( int i = 0; i < sqlLiteReader.FieldCount; i++ )
                    {
                        // either adress the column via an index or its name
                        var columnContentAsString = sqlLiteReader[ i ].ToString( );
                        allRecords.Append( columnContentAsString );
                    }
                    allRecords.Append( Environment.NewLine );
                }
                textBox1.Text = allRecords.ToString( );
            }
        }
        // somehow close/dispose your connection
    }
