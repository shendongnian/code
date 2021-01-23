    public IHttpActionResult Edit(User user)
        {
           try
           {
              User original = db.FirstOrDefault(u=>u.Id==user.Id);
              original.Name = user.Name;
    
              if (ModelState.IsValid)
              {
                 db.Entry(original).State = EntityState.Modified;
                 db.SaveChanges();
              }
           }
           catch (Exception e)
           {
        
           }
        }
