    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    public class ProductsViewModel
    {
        public string Xml { get; set; }
        public Product Poco { get; set; }
        public ProductsViewModel()
        {
            Xml = Serialize(new Product());
            Poco = (Product)Deserialize(Xml, typeof(Product));
        }
        public class Price
        {
            [XmlAttribute(AttributeName = "price")]
            public int Value { get; set; }
        }
        [XmlRoot(ElementName = "products")]
        public class Product
        {
            [XmlAttribute(AttributeName = "grand-total")]
            public int GrandTotal { get; set; }
            [XmlElement(ElementName = "one")]
            public Price OnePrice { get; set; }
            [XmlElement(ElementName = "two")]
            public Price TwoPrice { get; set; }
            [XmlElement(ElementName = "tree")]
            public Price ThreePrice { get; set; }
            public Product()
            {
                GrandTotal = 100;
                OnePrice = new Price { Value = 50 };
                TwoPrice = new Price { Value = 20 };
                ThreePrice = new Price { Value = 30 };
            }
        }
        private string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
        private object Deserialize(string serializedObj, Type type)
        {
            var serializer = new XmlSerializer(type);
            using (var stringReader = new StringReader(serializedObj))
            using (var xmlTextReader = new XmlTextReader(stringReader))
            {
                return serializer.Deserialize(xmlTextReader);
            }
        }
    }
