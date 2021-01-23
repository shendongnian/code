    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop()
            {
                Name = "Jack's Shop",
                Customers = new List<Customer>() 
                {  
                    new Customer() { FirstName = "Maynard", LastName = "Keating" },
                }
            };
    
            XmlSerializer xmls = new XmlSerializer(typeof(Shop));
    
            using (FileStream fs = File.Create("JacksShop.xml"))
                xmls.Serialize(fs, shop);
        }
    }
    
    [XmlRoot]
    public class Shop
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
    
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
