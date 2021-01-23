    private static Series GetBuysSeries(List<Order> buys)
    {
        return GetSeries(buys, buy => buy.Price, buy => buy.Quantity);
    }
    
    private Series GetPriceSeries(List<Trade> trades)
    {
        return getSeries<Trade>(trades,
                                trade => trade.DateTimeUtc,
                                trade => trade.UnitPrice);
    }
    
    private Series GetSeries<T>(List<T> list,
                                Func<T, double> selector1,
                                Func<T, double> selector2)
    {
        var series = new Series();
        foreach (var item in list)
        {
            series.Points.AddXY(selector1(item), selector2(item));
        }
        return series;
    }
