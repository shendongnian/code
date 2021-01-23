    Dictionary<string,string> Clean( Dictionary<string,string> dictionary , params string[] words )
    {
      string pattern = @"\b(" + string.Join( "|" , words.Select( Regex.Escape ) ) + @")\b" ;
      Regex rx = new Regex(pattern,RegexOptions.IgnoreCase) ;
      
      foreach ( string key in dictionary.Keys )
      {
        dictionary[key] = rx.Replace(dictionary[key],"") ;
      }
      
      return dictionary ;
    }
