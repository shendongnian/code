    public IEnumerable<TcAdsSymbolInfo> GetSymbols(IEnumerable<TcAdsSymbolInfo> set)
    {
        if (!set.Any())
            return Enumerable.Empty<TcAdsSymbolInfo>();
    
        return set.SelectMany(sym => GetSymbols(sym.SubSymbols)));
    }
