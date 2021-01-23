    public void updateShoes(Shoe shoe) 
    {
        var query = from b in db.BrandTbls.AsQueryable()
                join m in db.ShoeModelTbls on b.BrandID equals m.BrandID
                join s in db.ShoeTbls on m.ModelID equals s.ModelID
                where shoe.ShoeID == s.ShoeID 
                orderby m.ModelName
                select new 
                { 
                    Shoe = shoe, Brand = b, Model = m
                };
        foreach(var o in query)
        {
            o.Shoe.ColorName = "Black";
            o.Brand.BrandName = "New Branding";
            o.Model.ModelName = "Something else";
        }
        db.SaveChanges();
    }
