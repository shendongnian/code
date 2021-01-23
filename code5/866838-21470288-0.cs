    finalList.AddRange(
        (from l1 in list1
         join l2t in list2 on 
             new { material = l1.parte.ToUpper().Trim(), Order = l1.orden.ToUpper().Trim() }
         equals
             new { material = l2.parte.ToUpper().Trim(), Order = l2.Order.ToUpper().Trim() }
         into list2Joined
         from l2 in list2Joined.DefaultIfEmpty()
         select new  ListSell
         {
             TotalQuantity = l1.TotalQuantity ,
             QuantitySell= l2.QuantitySell,
             Desc= l1.Desc,
             Material = l1.Material ,
             Orden = l1.orden
         }).ToList());
