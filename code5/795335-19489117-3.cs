    var q1 = db.FeeInvoice.Where(fi => [QUERY1]));
    
     if (isPresented != null)
     {
         var q2 = db.FeeInvoice.Where(fi =>[QUERY2]));
    
         q1.Union(q2);
     }
    
     if (ID != null)
     {
         var q3 = db.FeeInvoice.Where(fi =>[QUERY3]);
    
         q1.Union(q3);
     }
    
    ...........................
