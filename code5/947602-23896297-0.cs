                var query = from b in db.BrandTbls.AsQueryable()
                        join m in db.ShoeModelTbls on b.BrandID equals m.BrandID
                        join s in db.ShoeTbls on m.ModelID equals s.ModelID
                        join i in db.ShoeImageTbls on s.ShoeID equals i.ShoeID
                        group new {b,m,s,i} by new {b.BrandName,m.ModelName,m.Price,s.ShoeID,s.PrimaryColor,s.SecondaryColor,i.ImagePath} into g
                        select new {g.Key.ShoeID,g.Key.BrandName,g.Key.ModelName,g.Key.ImagePath,g.Key.Price};
