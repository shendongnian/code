    order.Items
       .GroupJoin (
          productNonCriticalityList, 
          i => i.ProductID, 
          p => p.ProductID, 
          (i, g) => 
             new  
             {
                i = i, 
                g = g
             }
       )
       .SelectMany (
          temp => temp.g.DefaultIfEmpty(), 
          (temp, p) => 
             new  
             {
                i = temp.i, 
                p = p
             }
       )
