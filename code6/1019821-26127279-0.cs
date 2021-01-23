    public class FruitCollection : Collection<Fruit>
    {
    	public FruitCollection(IList<Fruit> source) : base(source)
    	{
    	}
    	
    	public FruitCollection()
    	{
    	}
    
        public FruitCollection Clone()
        {
            return Clone(this);
        }
    
        public static FruitCollection Clone(FruitCollection fruitCollection)
        {
    		// ToList() will give a new List. Otherwise Collection will use the same IList we passed.
            return new FruitCollection(fruitCollection.ToList());
        }
    
    }
    
    void Main()
    {
    	var basket1 = new FruitCollection();
    	basket1.Add(Fruit.Apple);
    	var basket2 = basket1.Clone();
    	basket2.Add(Fruit.Orange);
    	Console.WriteLine("{0}", basket1.Count);
    	Console.WriteLine("{0}", basket2.Count);
    }
