    using (WebApplication1Entities db = new WebApplication1Entities())
    {
       var order = db.Orders.GetAll().FirstOrDefault(x=> x.Transaction == txnId);
       if(order != null) // update
       {
          //.....
          db.SaveChanges();
        }
       else
       {
          // new
       }
    }
       
