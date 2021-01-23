    private static SymbolInfo LoadTree()
    {
      SymbolInfo a = new SymbolInfo("A") ;
      SymbolInfo b = new SymbolInfo("B") ;
      SymbolInfo c = new SymbolInfo("C") ;
      SymbolInfo d = new SymbolInfo("D") ;
      SymbolInfo e = new SymbolInfo("E") ;
      SymbolInfo f = new SymbolInfo("F") ;
      SymbolInfo g = new SymbolInfo("G") ;
      SymbolInfo h = new SymbolInfo("H") ;
      SymbolInfo i = new SymbolInfo("I") ;
      
      a.Subsymbols.Add(b) ;
      a.Subsymbols.Add(c) ;
      a.Subsymbols.Add(d) ;
      
      b.Subsymbols.Add(e) ;
      
      c.Subsymbols.Add(f) ;
      c.Subsymbols.Add(g) ;
      
      f.Subsymbols.Add(h) ;
      f.Subsymbols.Add(i) ;
      
      return a ;
    }
