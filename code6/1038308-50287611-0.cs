    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
    	    //  Fetch a list of all the [User] records, just for the hell of it.
    	    var users = await Task.Run(() => dbContextWebMgt.Users.ToList());
    	    return new OkObjectResult(users);
        }
        catch (Exception ex)
        {
    	    return new BadRequestObjectResult(ex.Message);
        }
    }
