    [HttpGet("User")]
    public async Task<UserViewModel> GetByName(string name)
    [HttpGet("User")]
    public async Task<UserViewModel> GetByUserName(string name)
    
    //You can access like 
    //- api/Users/User?name=someneme
    //- api/Users/User?username=someneme
