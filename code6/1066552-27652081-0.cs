    public IEnumerable<PriceOfMetal> GetPrice(int id, DateTime time)
    {
        DateTime timenew = time.AddDays(-1);
        var allPrice = from c in db.PriceOfMetal
                       select c;
                       where c.Date.Date == timenew.Date
                       and c.ListOfMetal_Id == id
        if (!allPrice.Any())
        {
            try
            {
                var price = WcfProvider.MetalsPrices(id, time, time).Tables[0].AsEnumerable()
                            .Select(a =>new PriceOfMetal
                            {
                                Date = a.Field<DateTime>("Date"),
                                ListOfMetaL_Id = a.Field<int>("MetalId"),
                                Value = a.Field<System.Double>("Price")
                            })
                            .ToList().Single();
                db.PriceOfMetal.Add(price);
                db.SaveChanges();
            }
            catch
            {
                // Eating exceptions like this is really poor. You should improve the design.
            }
        }
        return db.PriceOfMetal;
    }  
