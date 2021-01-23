    public class ThingsPrices
        {
            public string ItemName { get; set; }
            public double Price { get; set; }
        }
    
    public ThingsPrices[] GetThings()
            {
    
                var things = new List<ThingsPrices>()
                {
                    new ThingsPrices
                    {
                        ItemName = "book",
                        Price = 0.5
                    },
                    new ThingsPrices
                    {
                        ItemName = "notepad",
                        Price = 1.2
                    }
                };
    
                return things.ToArray();
            }
