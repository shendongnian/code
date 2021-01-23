    using(var dbContext = new DBContext())
    {
       // Map our (Business)Asset to our (Entity Framework)Asset
       var dataAsset = Mapper.Map<Business.Asset, Data.Asset>(asset);
       var oldEntity = dbContext.Assets.FirstOrDefault(m => m.Id == dataAsset.Id);
       dbContext.Entry(oldEntity).CurrentValues.SetValues(dataAsset);
       
       dbContext.SaveChanges();
    }
