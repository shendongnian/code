    string previousDate = String.Empty;
    for( int i = 0; i < dt.Rows.Count; i++ )
    {
        string currentDate = dt.Rows[i]["Date"].ToString();
        if( previousDate != currentDate )
        {
            Console.WriteLine( currentDate );
        }
        Console.WriteLine( dt.Rows[i]["News"].ToString() );
    }
