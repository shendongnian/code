    public async Task<IHttpActionResult> GetMapData(IEnumerable<IIdentifiableStatus> statuses)
    {
        var result = await statuses
            .Select(e => new {
                Id = e.Id,
                Name = e.Name
            })
            .ToListAsync();
        return Ok(result);
    }
