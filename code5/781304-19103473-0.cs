    [XmlRoot("Product")]
    public class Product
    {
        [XmlElement("ID")]
        public int ID { get; set; }
        [XmlElement("name")]
        public string name { get; set; }
        [XmlElement("price")]
        public decimal price { get; set; }
        [XmlElement("mass")]
        public double mass { get; set; }
        public static void serialization()
        {
            List<Product> listprod = new List<Product>();
            listprod.Add(new Product() { ID = 1, name = "Samochod", price = 20, mass = 1000 });
            XmlRootAttribute root = new XmlRootAttribute("Products");
            TextWriter textwriter = new StreamWriter(@"C:\temp\Products.xml");
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Product>), root);
            xmlserializer.Serialize(textwriter, listprod);
            textwriter.Close();
        }
    }
