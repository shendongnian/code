        class Program
        {
            private static void Main(string[] args)
            {
                //Same as above
                const string xmlFile = "CustomerPo.xml";
                var objStreamReader = new StreamReader(xmlFile);
                var xmlData = new XmlSerializer(new XmlPurchaseOrder().GetType());
                var po = (XmlPurchaseOrder)xmlData.Deserialize(objStreamReader);
                objStreamReader.Close();
            //Now utilizing the factory.
            var mf = new CustomerMapFactory();
            var poMap = mf.CreateInstance("BkMap");
            var customerOrder = poMap.MapToCustomerOrder(po);
        }
