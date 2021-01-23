    csv.WillThrowOnMissingField = false;
    var list = new List<MyObject>();
    var headerChecked = false;
    while( csv.Read() )
    {
        if( !headerChecked )
        {
            // check for specific headers
            if( !csv.FieldHeaders.Exists( "MyHeaderName" ) )
            {
                throw new Exception( "message" );
            }
            headerChecked = true;
        }
    
        list.Add( csv.GetRecord<MyObject>() );
    }
