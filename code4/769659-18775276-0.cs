    static void OrganizeFiles( DirectoryInfo src , DirectoryInfo tgt )
    {
      foreach ( FileInfo file in src.EnumerateFiles("result*.xml") )
      {
        Match m = FileNamePatternRegex.Match( file.Name ) ;
        bool processed = false ;
        if ( m.Success)
        {
          string datetime = m.Groups["datetime"].Value ;
          DateTime resultDate ;
          bool parseSucceeded = DateTime.TryParseExact( datetime , "M_d_yyyy h_m_s tt" , CultureInfo.InvariantCulture , DateTimeStyles.AllowWhiteSpaces , out resultDate ) ;
          if ( parseSucceeded )
          {
            DirectoryInfo subDir = tgt.CreateSubdirectory( resultDate.ToString(  @"yyyy\MM\dd" ) ) ;
            string newName     = resultDate.ToString( "result.yyyy-MM-ddTHH:mm:ss.xml" ) ;
            string destination = Path.Combine( subDir.FullName , newName ) ;
            file.MoveTo( destination ) ;
            processed = true ;
          }
        }
        if ( !processed )
        {
          Console.WriteLine( "skipping file {0}" , file.FullName ) ;
        }
      }
      return ;
    }
    const string          FileNamePattern      = @"^result(?<datetime>\d+_\d+_\d+ +\d+_\d+_\d+ +(am|pm))\.xml" ;
    static readonly Regex FileNamePatternRegex = new Regex( FileNamePattern , RegexOptions.IgnoreCase|RegexOptions.ExplicitCapture ) ;
