    public async Task<IHttpActionResult> GetMyItems()
    {
        if(!authorized)
            return Unauthorized();
        if(myItems.Count == 0)
            return NotFound();
        //... code ..., var myItems = await ...
        return Ok(myItems);
    }
