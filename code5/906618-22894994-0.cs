                json = reader.ReadToEnd();
}
            var jsonObj = new JavaScriptSerializer().Deserialize<ShoppingCart>(json);
            List<ShoppingCart> newItem = new List<ShoppingCart>();
            newItem.Add(new ShoppingCart(jsonObj.ProductId,
                                         jsonObj.ProductTitle,
                                         jsonObj.DefaultImagePath,
                                         jsonObj.Quantity,
                                         jsonObj.Price,
                                         jsonObj.Total);
