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
			if (!AllowanceExists(id))
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
