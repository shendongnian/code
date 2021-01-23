    public IHttpActionResult Edit(User user)
    {
       try
       {
          if (ModelState.IsValid)
          {
             db.Entry(user).State = EntityState.Modified;
             db.SaveChanges();
          }
       }
       catch (Exception e)
       {
    
       }
    }
