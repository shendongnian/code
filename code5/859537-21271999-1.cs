    public static IEnumerable<string> TreeWalk( SymbolInfo root , List<SymbolInfo> visited )
    {
      if ( root != null )
      {
        visited.Add(root) ;
        yield return string.Join( " -> " , visited ) ;
        foreach ( SymbolInfo child in root.Subsymbols )
        {
          foreach ( string childPath in TreeWalk( child , visited ) )
          {
            yield return childPath ;
          }
        }
        visited.RemoveAt(visited.Count-1) ;
      }
    }
