    var hubConnection = new HubConnection("http://www.contoso.com/");
    IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
    stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price));
    
    stockTickerHub.On("notify", () =>
        // Context is a reference to SynchronizationContext.Current
        Context.Post(delegate
        {
            textBox.Text += "Notified!\n";
        }, null)
    );    
    
    await hubConnection.Start();
    // or do the following for a synchronous method:
    // connection.Start().Wait();
