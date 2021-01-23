     foreach(var line in cart.Lines) {
         
         Orders dbEntry = new Orders();
         
         dbEntry.ProductID = line.Product.ProductID;
         dbEntry.Quantity = line.Quantity;
         dbEntry.OrderTotal = line.Quantity * line.Product.Price;
         dbEntry.Name = shippingInfo.Name;
         dbEntry.Line1 = shippingInfo.Line1;
         dbEntry.Line2 = shippingInfo.Line2;
         dbEntry.Line3 = shippingInfo.Line3;
         dbEntry.City = shippingInfo.City;
         dbEntry.State = shippingInfo.State;
         dbEntry.Zip = shippingInfo.Zip;
         dbEntry.Country = shippingInfo.Country;
         dbEntry.GiftWrap = shippingInfo.GiftWrap;
    
         context.Orders.Add(dbEntry);
         
     }
    
    context.SaveChanges();
