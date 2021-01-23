    public string Decode(string text)
    {
        var replacements = new Dictionary<string, char> {
          { "&#8217;", ''' },
          // ...etc
        }
        
        var sb = new StringBuilder( text );
        
        foreach( var c in replacements.Keys ) {
          sb.Replace( c.ToString(), replacements[c] );
        }
        return sb.ToString();
    }
