    SomeType SomeMethod(int itemId)
    {
        for (int cun = 0; cun < ItemIdNumber.Length; cun++)
        {
            int Item_Id = Convert.ToInt32(ItemIdNumber[cun]);
        
            for (int yyu = 0; yyu <= 1258038; yyu++)
            {        
                if (c[yyu] == itemId) return yyu;
            }
        }
        return null;
    }
