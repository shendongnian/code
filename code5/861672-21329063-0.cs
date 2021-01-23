    static void Main()
    {
        var testStrings = new[] { "", "1.234" };
        foreach( var testString in testStrings )
        {
            double output;
            double? value = null;
            if( double.TryParse( testString, out output ) )
            {
                value = output;
            }
            Console.WriteLine( "{0}", value.HasValue ? value.Value.ToString() : "<null>" );
        }
    }
