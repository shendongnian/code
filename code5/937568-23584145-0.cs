    public class Fruit
        {
    
            public int Quantity { get; set; }
            public string Name { get; set; }
        }
    
        static void Main(string[] args)
            {
    
                var fruits = new List<Fruit>
                {
                    new Fruit {Name = "Apple", Quantity = 10},
                    new Fruit {Name = "Orange", Quantity = 20},
                    new Fruit {Name = "Orange", Quantity = 60},
                    new Fruit {Name = "Apple", Quantity = 50}
                };
    
    
                var groupedFruit = fruits.GroupBy(l => l.Name)
                              .Select(lg =>
                                    new
                                    {
                                        Name = lg.Key,
                                        TotalQuantity = lg.Sum(q => q.Quantity)
                                    });
    
                foreach (var fruit in groupedFruit)
                {
                    Console.WriteLine("Fruit: {0} : Quantity: {1}", 
                        fruit.Name, fruit.TotalQuantity);
                }
    
                Console.Read();
            }
