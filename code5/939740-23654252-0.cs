    using (WebApplication1Entities db = new WebApplication1Entities())
    {
       var order = db.Orders.GetAll().Where(x=> x.Transaction == txnId).FirstOrDefault();
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
       
