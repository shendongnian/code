    string filePath = @"C:\Error.txt";
    Exception ex = ...
    using( StreamWriter writer = new StreamWriter( filePath, true ) )
    {
        writer.WriteLine( "-----------------------------------------------------------------------------" );
        writer.WriteLine( "Date : " + DateTime.Now.ToString() );
        writer.WriteLine();
        while( ex != null )
        {
            writer.WriteLine( ex.GetType().FullName );
            writer.WriteLine( "Message : " + ex.Message );
            writer.WriteLine( "StackTrace : " + ex.StackTrace );
            ex = ex.InnerException;
        }
    }
