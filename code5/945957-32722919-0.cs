    var UpdQuery = (from b in db.BrandTbls
                join m in db.ShoeModelTbls on b.BrandID equals m.BrandID
                join s in db.ShoeTbls on m.ModelID equals s.ModelID
                where shoe.ShoeID == s.ShoeID 
                orderby m.ModelName
                select new { b, m, s }
                // now for the update portion of the query
                ).Select(result =>
                { 
                    result.s.ShoeID = shoe.ID;
                    result.s.Size = shoe.Size;
                    result.s.PrimaryColor = shoe.PrimaryColor;
                    result.s.SecondaryColor = shoe.SecondaryColor;
                    result.s.Quantity = shoe.Quantity;
                    result.m.ModelName = shoe.ModelName;
                    result.m.Price = shoe.Price;
                    result.b.BrandName = shoe.BrandName;
                    return result; // this is important
                }).ToList();  // tolist actually runs the query to update the objects
    db.SaveChanges(); // write changes back to DB
    
