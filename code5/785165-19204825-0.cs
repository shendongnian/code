    internal sealed class ParseStatus
    {
        internal bool IsSuccess;
        internal IReadOnlyList<string> Messages;
    }
    
    private ParseStatus Load()
    {
        string filePath = "foo";
    
        var data = File.ReadLines( filePath ).Select( line => line.Split( '\t' ) ).ToArray();
        var results = from x in data
                        select new { Name = x[3], Age = x[1], Date = x[2], Time = x[5], Score = x[7] };
    
        var errors = new List<string>();
        int row = 0;
    
        // first pass: look for errors by testing each value
        foreach( var line in results )
        {
            row++;
    
            int dummy;
            if( !int.TryParse( line.Age, out dummy ) )
            {
                errors.Add( "Age couldn't be parsed as an int on line " + row );
            }
    
            // etc...use exception-free checks on each property
        }
    
        if( errors.Count > 0 )
        {
            // quit, and return errors list
            return new ParseStatus { IsSuccess = false, Messages = errors };
        }
        
        // otherwise, it is safe to load all rows
        // TODO: second pass: load the data
    
        return new ParseStatus { IsSuccess = true };
    }
