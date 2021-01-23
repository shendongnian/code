    public class Stock
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [MaxLength(8)]
            public string Symbol { get; set; }
    }
    
    public class Valuation
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [Indexed]
            public int StockId { get; set; }
            public DateTime Time { get; set; }
            public decimal Price { get; set; }
    }
