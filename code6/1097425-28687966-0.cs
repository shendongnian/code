      public void UpdateProductQuantity(int productID, int quantity)
      {
           product = products.Where(x => x.ID == productID).FirstOrDefault();
           if(product != null)
           {
             product.Quantity = quantity;
           }
      }
