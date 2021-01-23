    Dictionary<string,string> Clean( Dictionary<string,string> dictionary , params string[] words )
    {
      string pattern = @"\b(" + string.Join( "|" , words.Select( x => Regex.Escape(x) ) ) + @")\b" ;
      Regex rx = new Regex(pattern,RegexOptions.IgnoreCase) ;
      
      Dictionary<string,string> cleaned = dictionary.Where( x => !rx.IsMatch(x.Value) )
                                                    .ToDictionary( x => x.Key , x => x.Value )
                                                    ;
      return dictionary ;
    }
