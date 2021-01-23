    Media test;
    //1. Get your element
    using (var db1 = new MediaDBEntities())
    {
      test = db1.Pages.Find(page.PageID);
    }
    
    //2. edit entities in disconnected mode (out of db1 scope)
    if (test != null)
    {
        test.prop1 = "some text";
    }
    
    //now save using new Context
    using (var db2 = new SchoolDBEntities())
    {
      //3. Mark entity as modified
       db2.Entry(test).State = System.Data.Entity.EntityState.Modified;     
            
       //4. call SaveChanges
       db2.SaveChanges();
    }
    
