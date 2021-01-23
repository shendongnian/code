    using (var db = new TradingContext())
    {               
        var tradeOfItem3 = db.Trades.
            FirstOrDefault(t => t.ItemsToReturn.Any(i => i.Id == 3) || t.ItemsToSend.Any(i => i.Id == 3));
    }
