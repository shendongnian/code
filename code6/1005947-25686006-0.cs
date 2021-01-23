     yourdataentity newentity = new yourdataentity();
     //this is one way to set the date for a new record...
     newentity.createDate = DateTime.Now;
    
     yourentitys.Add(newentity);
    
     if (ModelState.IsValid)
     {
          db.yourentitys.Add(newentity);
          db.SaveChanges();
     }
