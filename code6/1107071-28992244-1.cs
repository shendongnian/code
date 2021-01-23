    Media test;
    //1. Get your element
    using (var db1 = new MediaDBEntities())
    {
      test = db1.Pages.Find(page.PageID);
    }
    
    //2. do other operations
    
    
    //now save using new Context
    using (var db2 = new SchoolDBEntities())
    {
      //3. Mark entity as Unchanged
       db2.Entry(test).State = System.Data.Entity.EntityState.Unchanged;     
            
       //4. call SaveChanges
       db2.SaveChanges();
    }
    
