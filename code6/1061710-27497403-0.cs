    [TestMethod]
    public void Xml_ShouldBeDeserialized()
    {
        var serializer = new XmlSerializer(typeof (Order));
        using (var stream = File.OpenRead(@"D:\test.xml"))
        {
            var obj = serializer.Deserialize(stream);
            var order = obj as Order;
            Assert.IsNotNull(order);                
        }
    }
    [XmlTypeAttribute(AnonymousType = true,
                  Namespace = "urn:schemas-alibaba-com:billing-data")]
    [XmlRoot(ElementName = "Order",
                      Namespace = "urn:schemas-alibaba-com:billing-data",
                      IsNullable = false)]
    public partial class Order
    {
        private string currencyField;
        private object descriptionField;
        public string Currency { get; set; }
        public string Description { get; set; }
    }
