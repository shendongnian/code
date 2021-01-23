    [HttpGet]
    public async Task<IActionResult> GetAsync()
    
    {
          IList myList = await FetchAsync();
    }
