    Dictionary<string,string> Clean( Dictionary<string,string> dictionary , params string[] words )
    {
      string pattern = @"\b(" + string.Join( "|" , words.Select( x => Regex.Escape(x) ) ) + @")\b" ;
      Regex rx = new Regex(pattern,RegexOptions.IgnoreCase) ;
      
      string[] keysToRemove = dictionary.Where( x => rx.IsMatch(x.Value) )
                                        .Select( x => x.Key )
                                        .ToArray()
                                        ;
      
      foreach ( string key in keysToRemove )
      {
        dictionary.Remove(key) ;
      }
      return dictionary ;
    }
