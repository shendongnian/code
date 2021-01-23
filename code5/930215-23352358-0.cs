    static Dictionary<string,IndexEntry> ProcessFiles( IEnumerable<string> filenames )
    {
      IEnumerable<string> words = filenames
                                  .AsParallel()
                                //.WithMergeOptions( ParallelMergeOptions.NotBuffered )
                                  .Select( x => ReadWordsFromFile(x) )
                                  .SelectMany( x => x )
                                  ;
      Dictionary<string,IndexEntry> index = new Dictionary<string,IndexEntry>() ;
      foreach( string word in words ) // would making this parallel speed things up? dunno.
      {
        bool found = index.ContainsKey(word) ;
        if ( !found )
        {
          index.Add( word, new IndexEntry() ) ;
        }
      }
      return index ;
    }
    
    static Regex rxWord = new Regex( @"\w+" ) ;
    private static IEnumerable<string> ReadWordsFromFile( string fn )
    {
      using( StreamReader sr = File.OpenText( fn ) )
      {
        string line ;
        while ( (line=sr.ReadLine()) != null )
        {
          for ( Match m = rxWord.Match(line) ; m.Success ; m = m.NextMatch() )
          {
            yield return m.Value ;
          }
        }
      }
    }
