    if (xmlReader.IsStartElement())
     {
     if (xmlReader.Name == "BuyNowPrice") 
          Console.WriteLine(xmlReader.Name + ": " 
                  + xmlReader.ReadElementContentAsString());
    }
