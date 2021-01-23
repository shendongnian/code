    public async Task<IHttpActionResult> PutParent(int id, Parent parent)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                if (id != parent.Id)
                {
                    return BadRequest();
                }
    
                db.Entry(parent).State = EntityState.Modified;
    
                foreach (Child child in parent.Children)
                {
                    db.Entry(child).State = child.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
    
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
    
                return Ok(db.Parents.Find(id));
            }
