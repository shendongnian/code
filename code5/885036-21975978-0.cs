    public virtual bool RemoveFromWishlist(int id)
    {
        bool removed = false;
        for (int x = Wishlist.Count - 1; x >= 0; x--)
        {
            if (Wishlist[x].Product.Id == id)
            {
                Wishlist[x].Customer = null;
                Wishlist.RemoveAt(x);
                removed = true;
            }
        }
        return removed;
    }
