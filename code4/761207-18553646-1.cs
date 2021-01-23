    public void CheckProductExistThenAddToCart(CartItem item)
    {
      var existingItem = CartItems
          .SingleOrDefault(i => i.ProductId.Equals(item.ProductId));
      if (existingItem == null)
      {
        AddToCart(item);
      }
      else
      {
        existingItem.Qty += item.Qty;
      }
    }
