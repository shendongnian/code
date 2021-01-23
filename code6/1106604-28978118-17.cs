    public HttpResponseMessage Put(int id,[FromBody]Search editFavorite)
    {
	    if (!ModelState.IsValid || id != editFavorite.Id)
		{
            return Request.CreateResponse(HttpStatusCode.BadRequest);
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
				return Request.CreateResponse(HttpStatusCode.NotFound);
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
