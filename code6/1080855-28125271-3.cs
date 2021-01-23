    var sandpTask = List<StockData> sandp = cache.GetAsync<List<StockData>>(sandpKey);
    var dateTask = cache.GetAsync<DateTime>(dateKey);
    var symbolinfoTask = cache.GetAsync<SymbolInfo>(symbolclassKey);
    var stockdataTask = cache.GetAsync<List<StockData>>(stockdataKey);
    var stockcomparedataTask = cache.GetAsync<List<StockMarketCompare>>(stockcomparedataKey);
    await Task.WhenAll(sandpTask, dateTask,symbolinfoTask,
        stockdataTask, stockcomparedataTask);
    List<StockData> sandp = sandpTask.Result;
    DateTime date = dateTask.Result;
    SymbolInfo symbolinfo = symbolinfoTask.Result;
    List<StockData> stockdata = stockdataTask.Result;
    List<StockMarketCompare> stockcomparedata = stockcomparedataTask.Result;
    
    StockRating rating = performCalculations(symbolinfo, date, sandp, stockdata, stockcomparedata);
