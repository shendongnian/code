     public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
       [ElasticProperty(Type = FieldType.Nested)]
        public IList<Price> Prices { get; set; }
    }
