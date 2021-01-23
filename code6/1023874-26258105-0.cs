     private IEnumerable<string> ReadData(string filepath)
     {
       var res = new List<string>( );
       var fileInfo = new FileInfo( filepath );
       if( !fileInfo.Exists )
       {
         throw new ArgumentException( "No file exist with the path " + filepath,
                                      "filepath" );
       }
       var fileStream = fileInfo.Open( FileMode.Open,
                                       FileAccess.Read );
       var file = new StreamReader( fileStream,
                                    Encoding.UTF8 );
       string lineOfText;
       while( ( lineOfText = file.ReadLine( ) ) != null )
       {
         var pattern = new Regex( @"^[\w]{2},[\w]{0,},[\w]{1,},([\w]{1,})(?:,[\w]{0,},[\w]{1,}){0,1};$");
         var match = pattern.Match( lineOfText );
         if( match.Success )
         {
           res.Add( match.Groups[ 0 ].Value );
         }
         else
         {
           // Handle lines with wrong format
         }
       }
      return res;
    }
