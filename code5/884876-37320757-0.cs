    public bool Update(ShopInformation entity)
    {
        if(GetAll().Any())
        {
            base.Update(entity);
            return true; // True because it updated
        }
        else
        {
             base.Add(entity);
             return false; // False because it didn't
        }
    }
