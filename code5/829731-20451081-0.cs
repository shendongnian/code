      string file = @"C:\Users\user\Desktop\test.xml";
      string id = "model1"; /* here you can set a parse dialog*/  
      string ModelID = "//model[@uri='" + id + "']";
      List<string> priceData = new List<string>();
      XmlDocument xDoc = new XmlDocument();
      xDoc.Load(file);
      XmlNodeList PriceNodeList = xDoc.SelectNodes(ModelID + "/PriceData/value");
      
      //looping through the all the node details one by one          
       foreach (XmlNode x in PriceNodeList)
       {
       //for the current Node retrieving all the Attributes details            
       var price = x.Attributes["double"];
       if (price == null) continue;
       priceData.Add(price.Value);
       }
