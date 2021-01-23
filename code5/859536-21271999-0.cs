    class SymbolInfo
    {
      public string Name { get ; set ; }
      public SortedSet<SymbolInfo> Subsymbols { get ; set ; } 
      
      public SymbolInfo( string name )
      {
        this.Name = name ;
        this.Subsymbols = new SortedSet<SymbolInfo>( new SymbolInfo.Comparer() ) ;
      }
      
      public override string ToString()
      {
        return this.Name ?? "-null-" ;
      }
      
      private class Comparer : IComparer<SymbolInfo>
      {
        public int Compare( SymbolInfo x , SymbolInfo y )
        {
          return string.Compare(x.Name,y.Name,StringComparison.InvariantCultureIgnoreCase) ;
        }
      }
    }
