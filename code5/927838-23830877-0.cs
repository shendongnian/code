    using(TransactionScope ts = new TransactionScope())
    {
       using(MyEntities entity = new MyEntities())
       {
         //... your code ...
         //...
         entity.SaveChanges();
       }
       ts.Complete();
    }
