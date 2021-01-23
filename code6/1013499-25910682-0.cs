    var products = new XElement(
                "products",
                new string[] {"first", "second"}
                    .Select(s => 
                        {
                            var data = GetData(s);
                            return new XElement(
                                "product",
                                new XElement("id", data.Id),
                                new XElement("price", data.Price));
                        }));
    var xmlString = products.ToString();
