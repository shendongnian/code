    public HttpResponseMessage Put(int id,[FromBody]Search editFavorite)
    {
	    if (!ModelState.IsValid)
		{
		    return BadRequest(ModelState);
	    }
        if (id != editFavorite.Id)
		{
            return BadRequest();
	    }
     	db.EditFavorite(editFavorite);
    	try
	    {
			db.Save();	
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!SearchExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}
		return Request.CreateResponse(HttpStatusCode.Created, editFavorite);
    }
    public bool SearchExists(int id)
    {
        return db.Search.Count(e => e.Id == id) > 0;
    }
