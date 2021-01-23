    static Dictionary<DateTime, List<double>> stocks = new Dictionary<DateTime, List<double>>(); 
    
    private static void AddStocks(DateTime dt, List<double> values) {
                stocks.Add(new DateTime(dt.Year, dt.Month, dt.Day), values);
            }
    
