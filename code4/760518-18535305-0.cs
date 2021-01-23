    if ( !System.IO.File.Exists( @"countryCode.txt" ) )
        throw new ApplicationException( "countryCode.txt is missing" );
    string[] data = File.ReadAllLines(@"countryCode.txt");
    if ( data.Length == 0 )
        throw new ApplicationException( "countryCode.txt contains no data" );
    string[] country = data[0].Split('#');
    if ( country.Length == 0 )
        throw new ApplicationException( "malformed data in countryCode.txt" );
    string temp = "";
    for (int i = 0; i < country.Length; i++ )
    {
        temp = country[i];
    }
    return temp.Split(':');
