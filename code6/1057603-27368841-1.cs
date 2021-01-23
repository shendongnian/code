    public class StockLevel
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }                        
    }
    static void Main(string[] args)
    {
        List<StockLevel> stockLevels = new List<StockLevel>()
        { 
            new StockLevel() { Date = DateTime.Parse("03-Feb-2014"), Quantity = 6 },
            new StockLevel() { Date = DateTime.Parse("04-Feb-2014"), Quantity = -1 },
            new StockLevel() { Date = DateTime.Parse("05-Feb-2014"), Quantity = -2 },
            new StockLevel() { Date = DateTime.Parse("06-Feb-2014"), Quantity = 2 },
            new StockLevel() { Date = DateTime.Parse("07-Feb-2014"), Quantity = -1 },
            new StockLevel() { Date = DateTime.Parse("08-Feb-2014"), Quantity = -2 },
            new StockLevel() { Date = DateTime.Parse("09-Feb-2014"), Quantity = -3 },
            new StockLevel() { Date = DateTime.Parse("10-Feb-2014"), Quantity = 5 },
        };
        var outOfStockDates = stockLevels
            .Where(a => a.Quantity < 0)
            .Select(a => new 
            { 
                    S1 = a.Date, 
                    S2 = stockLevels
                            .Where(c => c.Date >= a.Date)
                            .TakeWhile(b => b.Quantity < 0)
                            .Select(b => b.Date).Max() 
            })
            .GroupBy(a => a.S2, a => a.S1, (S2, S1S) => new { FromDate = S1S.Min(), ToDate = S2 });
        Console.ReadKey();
    }
