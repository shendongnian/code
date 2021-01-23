            // POST api/values
            [HttpPost]
            [ResponseType(typeof(CheckOut))]
            public async Task<IHttpActionResult> Post([FromBody] CheckOut checkOut)
            {
                if (checkOut == null)
                {
                    return BadRequest("Invalid passed data");
                }
    
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                db.checkOuts.Add(checkOut);
    
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (checkOutExists(checkOut.id))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
    
                return CreatedAtRoute("DefaultApi", new { id = checkOut.Id }, checkOut);
            }
