     public void Update(object entity)
     {   
         using (var _db = new MyEntities())
         {           
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;             
            _db.SaveChanges();
         }
     }
