    public static IEnumerable<string> ReadStringsFromFile( string fileName )
    {
      using ( StreamReader reader = File.OpenText( fn ) )
      {
        string s ;
        while ( null != (s=reader.ReadLine()) )
        {
          yield return s ;
        }
      }
    }
    
    ...
    
    Parse( ReadStringsFromFile() ) ;
