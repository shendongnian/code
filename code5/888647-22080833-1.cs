    var qr = (from s1 in SalesRecords
               group s1 by s1.PLUId into g
               select new SalesRecord{ 
                            PLUId = g.Key ,
                            Quantity = g.Sum( m =>m.Quantity ) ,
                            Subtotal = g.Sum( m=> m.Subtotal) })
                            .ToList();
    Console.WriteLine("PLUId Quantity Subtotal");  
    foreach (var s in qr)
          Console.WriteLine("{0,7} {1,9} {2,9}",s.PLUId, s.Quantity, s.Subtotal);    
