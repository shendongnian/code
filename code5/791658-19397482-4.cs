    [HttpGet("")]
    public async Task<UserViewModel> GetAll()
    [HttpGet("")]
    public async Task<UserViewModel> Get(int id)
    [HttpGet("")]
    public async Task<UserViewModel> GetByName(string name)
    [HttpGet("")]
    public async Task<UserViewModel> GetByUserName(string name)
    
    //You can access like 
    //- api/Users/
    //- api/Users/?id=123
    //- api/Users/?name=someneme
    //- api/Users/?username=someneme
