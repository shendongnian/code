    // Note: this first example is *not* what you want.
    // However, it is what your method's signature promises to do.
    public async Task<IEnumerable<Symbol>> GetSymbolsAsync()
    {
        var historicalFinancialTask = new List<Task<HistoricalFinancialResult>>();
        foreach (var symbol in await _listSymbols)
        {
            historicalFinancialTask.Add(GetFinancialsQueryAsync(symbol));
        }
        var results = new List<Symbol>();
        while (historicalFinancialTask.Count > 0)
        {
            var historicalFinancial = await Task.WhenAny(historicalFinancialTask);
            historicalFinancialTask.Remove(historicalFinancial);
            results.Add(new Symbol(historicalFinancial.Result.Symbol.Identifier, historicalFinancial.Result.Symbol.HistoricalQuotes, historicalFinancial.Result.Data)); 
        }
        return results;
    }
