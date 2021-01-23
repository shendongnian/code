    var xdoc = XDocument.Load(@"C:\Desktop\CteWebservice.xml");
    XNamespace soap = "http://www.w3.org/2001/12/soap-envelope";
    XNamespace m = "http://www.example.org/stock";
    var responseXml = xdoc.Element(soap + "Envelope").Element(soap + "Body")
                          .Element(m + "GetStockPriceResponse");
    var serializer = new XmlSerializer(typeof(GetStockPriceResponse));
    var responseObj =
          (GetStockPriceResponse)serializer.Deserialize(responseXml.CreateReader());
    [XmlRoot("GetStockPriceResponse", Namespace="http://www.example.org/stock")]
    public class GetStockPriceResponse
    {
        public decimal Price { get; set; }
    }
