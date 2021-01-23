    using( IDbCommand cmd = GetCommand() )
    {
        string lotSize = "12345";
        bool includeLotSize = !string.IsNullOrWhiteSpace( lotSize );
        var sb = new StringBuilder();
        sb.AppendLine( "SELECT Col1, Col2 FROM dbo.Foo" );
        // you might also vary the columns returned based on what the user asked for
        if( includeLotSize )
        {
            sb.AppendLine( "WHERE LotSize = @LotSize" );
            // The query will expect the lot size, so add a parameter here to pass 
            // the lot size value.
            cmd.Parameters.Add( new SqlParameter( "LotSize", lotSize ) );
        }
    }
