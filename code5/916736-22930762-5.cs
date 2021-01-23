    if (e.Error != null)
    {
       lstAromaticsPrices.ItemsSource = 
          new List<Prices>
          {
              new Prices()
              {
                  category = "No Categories available",
                  price = "0.00$"
              },
              new Prices()
              {
                  category = "No Prices available",
                  price = "0.00€"
              }
          };
       return;
    }
    XElement element = XElement.Parse(e.Result.ToString());
    List<Prices> prices = (from p in element.Descendants("Table")
                               orderby (string)p.Element("category")
                               select new Prices
                               {
                                   category = p.Element("category").Value,
                                   price = p.Element("price").Value,
                                   //priceDate = (string)p.Element("priceDate")
                               }).ToList<Prices>();
    //lstAromaticsPrices.ItemsSource = null;
    if(prices.Any())
        lstAromaticsPrices.ItemsSource = prices;
