    public void FilterProducts(string input, string output)
    {
        if (input != null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(input);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nameList = root.GetElementsByTagName("name");
            XmlNodeList priceList = root.GetElementsByTagName("price");
            XmlNodeList stackList = root.GetElementsByTagName("stack");
            XmlDocument outputDoc = new XmlDocument();
            XElement products = new XElement("products");
            outputDoc.AppendChild(products);
            for (int i = 0; i < nameList.Count; i++)
            {
                double quantityOnStack = Convert.ToDouble(stackList[i].InnerText);
                if (quantityOnStack >= 5)
                {
                    XmlElement product= outputDoc.CreateElement("product");
                    product.SetAttribute("id", (i + 1).ToString());
                    XmlElement name = outputDoc.CreateElement("name");
                    name.InnerText = nameList[i].InnerText;
                    product.AppendChild(name);
                    XmlElement price = outputDoc.CreateElement("price");
                    price.InnerText = priceList[i].InnerText;
                    product.AppendChild(price);
                    XmlElement stack = outputDoc.CreateElement("stack");
                    stack.InnerText = stackList[i].InnerText;
                    product.AppendChild(stack);
                    products.AppendChild(product);
                }
            }
            outputDoc.Save(output);
        }
        else
        {
            MessageBox.Show("File doesn't exist.");
        }
    }
