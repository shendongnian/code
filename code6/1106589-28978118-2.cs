	     if (!ModelState.IsValid)
		 {
		     return BadRequest(ModelState);
	     }
         if (id != editFavorite.Id)
			{
				return BadRequest();
			}
			db.EditFavorite(id, editFavorite);
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
