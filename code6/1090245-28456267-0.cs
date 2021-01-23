    class DailyValuesWithTotal : DailyValues
    {
        decimal Total
    }
    var projectedValues = values.Select( (v,i) => new DailyValuesWithTotal(){
        Date = v.Date,
        Open = v.Open,
        High = v.High,
        Low = v.Low,
        Volume = v.Volume,
        AdjClose = v.AdjClose,       
        Total = (i == 0) ? 0.0 : values[i-1].Total + (v.Volume + v.AdjClose)
    })
