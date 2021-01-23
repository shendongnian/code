    public class Program
    {
        public static void Main()
        {
            var items = new List<DataItem>
    		{
    			new DataItem { Position = "001", Description = "test", Value = 2.5m },
    			new DataItem { Position = "002", Description = "", Value = 1m },
    			new DataItem { Position = "001", Description = "hello", Value = 1.5m },
    			new DataItem { Position = "002", Description = "test2", Value = 2m }
    		};
    
            var results = 
                items
                .GroupBy(x => x.Position, (key, values) => new { Position = key, Values = values })
                .Select(g => new DataItem() 
                { 
                    Position = g.Position, 
                    Value = g.Values.Sum(x => x.Value) 
                });
        }
    }
    
    public class DataItem
    {
        public string Position { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
