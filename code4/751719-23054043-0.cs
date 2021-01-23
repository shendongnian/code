    public async IEnumerable<Task<Symbol>> GetSymbolsAsync()
    {
        var historicalFinancialTask = new List<Task<HistoricalFinancialResult>>();
        foreach (var symbol in await _listSymbols)
        {
            historicalFinancialTask.Add(GetFinancialsQueryAsync(symbol));
        }
        while (historicalFinancialTask.Count > 0)
        {
            var historicalFinancial = await Task.WhenAny(historicalFinancialTask);
            historicalFinancialTask.Remove(historicalFinancial);
            yield return new Symbol(historicalFinancial.Result.Symbol.Identifier, historicalFinancial.Result.Symbol.HistoricalQuotes, historicalFinancial.Result.Data); 
        }
    }
