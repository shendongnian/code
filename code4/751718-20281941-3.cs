    // Unlike this first example, this *is* what you want.
    public IObservable<Symbol> GetSymbolsRx()
    {
        return Observable.Create<Symbol>(async obs =>
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
                obs.OnNext(new Symbol(historicalFinancial.Result.Symbol.Identifier, historicalFinancial.Result.Symbol.HistoricalQuotes, historicalFinancial.Result.Data));
            }
        });
    }
