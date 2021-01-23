    public void CheckProductExistThenAddToCart(CartItem item)
    {
        if (CartItems.Count == 0) AddToCart(item);
        // missing return
        bool itemFound = false;
        foreach (var cartItem in CartItems)
        {
            if (cartItem.ProductId.Equals(item.ProductId))
            {
                itemFound = true; // ypu will find the same item you have justb added
                // ... causes this bug and is less efficient
                cartItem.Qty += item.Qty;
                ...
