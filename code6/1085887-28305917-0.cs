    [Route("{id:int}")]
    [ResponseType(typeof(ActivityDto))]
    public async Task<IHttpActionResult> GetActivity(int id)
    {
        ActivityDto activity = await db.Activities.Include(b => b.Location)
		    .Include(act => act.ImageReference)
			.Include(act => act.ThisIsAnArrayOfObjects)
			.Include(act => act.ThisIsAnArrayOfObjects.Select(arr => arr.ThisIsAnObjectOfTheArray)
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
