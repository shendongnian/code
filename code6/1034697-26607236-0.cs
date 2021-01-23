    public string getData(ref XmlDocument doc) {
            JObject productobj = new JObject();
            var productsenum = from p in doc.GetElementsByTagName("product").Cast<XmlElement>()
                               select p;
            JArray products = new JArray();
            foreach (XmlElement p in productsenum) {
                JObject pobj = new JObject();
                pobj["ProductCode"] = p.GetAttribute("ProductCode");
                pobj["CategoryName"]= p.GetAttribute("CategoryName");
                                
                products.Add(pobj);
            }
            JObject product = new JObject();
            product["Product"] = products;
            productobj["Products"] = product;
            return productobj.ToString();
        }
