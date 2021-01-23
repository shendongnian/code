    public static partial class ObservableExtensions
    {
        public static IObservable<Stock> ToStock(this IObservable<decimal> prices, string symbol)
        {                                                
            return Observable.Create<Stock>(o =>
            {
                Stock lastStock;            
                Action<decimal> action = null;
                action = price => {
                    lastStock = new Stock(symbol, price);
                    action = newPrice =>
                        {
                            lastStock = lastStock.Change(newPrice);
                            o.OnNext(lastStock);
                        };
                    o.OnNext(lastStock);
                };
            
                return prices.Subscribe(p => action(p), o.OnError, o.OnCompleted);
            });    
        }   
    }
