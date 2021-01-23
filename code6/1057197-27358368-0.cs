     public void Update(object entity)
     {   
         using (var _db = new MyEntities())
         {
            var table  = _db.Set(entity.GetType());
            table.Attach(entity);
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;             
            _db.SaveChanges();
         }
     }
