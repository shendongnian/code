    public interface IProduct 
    {
        int id { get; set; }
        string name { get; set; }
    }
    
    public class Product1 : IProduct
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class Product2 : IProduct
    {
        public int id { get; set; }
        public string name { get; set; }
    }
