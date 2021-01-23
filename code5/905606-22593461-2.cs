    public class Parameter
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    public class Prices
    {
        public Prices (IEnumerable<Parameter> parameters) 
        { 
            ... 
        }
    }
