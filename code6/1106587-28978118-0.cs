     public IHttpActionResult PutAllowance(int id, Allowance allowance)
     {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (id != allowance.Id)
			{
				return BadRequest();
			}
			db.UpdateAllowance(allowance, session.UserId);
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
			return StatusCode(HttpStatusCode.NoContent);
		}
