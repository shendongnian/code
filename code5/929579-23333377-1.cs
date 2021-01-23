    // somewhere in your code (for example MainPage class)
    Basket basket = new Basket();
    // and upon click, there were some items added:
    basket.Items.Add(new Shop { photo = "aaa.png", breed = "bbb", age = new DateTime(2000, 11, 20, 20, 12, 10), name = "turtle", price = 100 });
    public void SaveBasket()
    {
        using (IsolatedStorageFile cart = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream isoStream = cart.CreateFile("Cart.xml"))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Basket));
            xmlSerializer.Serialize(isoStream, basket);
        }
    }
    public void LoadBasket()
    {
        using (IsolatedStorageFile cart = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream isoStream = cart.OpenFile("Cart.xml", FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Basket));
            basket = (Basket)xmlSerializer.Deserialize(isoStream);
        }
    }
