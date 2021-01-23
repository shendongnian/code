    foreach(var item in LoadedList.Where(r=>r.LoadingType == "U"))
    {
        item.Quantity *= -1;
    }
    
    var summary = from d in LoadedList
                  group d by new { Brand = d.BrandCode, Packing = d.PackingCode, Grade = d.GradeCode } into g 
                  select new { Brand = g.Key.Brand, Packing = g.Key.Packing, Grade = g.Key.Grade, Quantity = g.Sum(e => e.LoadingQty) }
