    private static Regex rxWord = new Regex( @"[^,]*") ;
    public static IEnumerable<string> CsvSplit( this string text )
    {
      for ( Match m = rxWord.Match(text) ; m.Success ; m = m.NextMatch() )
      {
        yield return m.Value ;
      }
    }
