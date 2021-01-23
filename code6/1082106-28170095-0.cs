    public bool AddShop2(Shop newShop, out Exception exception)
        {
            exception = null;
            try
            {
                if (newShop == null || ShopDictionary.ContainsKey(newShop.ShopId))
                {
                    return false;
                }
                ShopDictionary.Add(newShop.ShopId, newShop);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return true;
        }
