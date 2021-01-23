    public IReceivableSourceBlock<Symbol> GetSymbolsAsync()
    {
        var block = new BufferBlock<Symbol>();
        GetSymbolsAsyncCore(block).ContinueWith(
            task => ((IDataflowBlock)block).Fault(task.Exception),
            TaskContinuationOptions.NotOnRanToCompletion);
        return block;
    }
    private async Task GetSymbolsAsyncCore(ITargetBlock<Symbol> block)
    {
        // snip
        while (historicalFinancialTasks.Count > 0)
        {
            var historicalFinancialTask =
                await Task.WhenAny(historicalFinancialTasks);
            historicalFinancialTasks.Remove(historicalFinancialTask);
            var historicalFinancial = historicalFinancialTask.Result;
            var symbol = new Symbol(
                historicalFinancial.Symbol.Identifier,
                historicalFinancial.Symbol.HistoricalQuotes,
                historicalFinancial.Data);
            await block.SendAsync(symbol);
        }
    }
