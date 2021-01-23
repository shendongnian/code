    public class Person
    {
        public int Id { get; set; }
        public  Supplier Supplier { get; set; }
        public  Consumer Consumer { get; set; }
        
        
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
    public class Consumer
    {
        public int Id { get; set; }
        public string Budget { get; set; }
    }
