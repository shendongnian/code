    [Route("{id:int}")]
    [ResponseType(typeof(ActivityDto))]
    public async Task<IHttpActionResult> GetActivity(int id)
    {
        ActivityDto activity = await db.Activities.Include(b => b.Location)
		    .Include(act => act.ImageReferences)
			.Include(act => act.Location.ObjectInLocation)			
            .Where(b => b.Id == id)
            .Select(AsActivityDto)
            .FirstOrDefaultAsync();
        if (activity == null)
        {
            return NotFound();
        }
        return Ok(activity);
    }
