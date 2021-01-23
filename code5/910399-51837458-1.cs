    [ProducesResponseType(typeof(DocumentInfo[]), 201)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string ar)
    {
        //  Put a breakpoint on the following line... what is the value of "ar" ?
        AccountRequest accountRequest = JsonConvert.DeserializeObject<AccountRequest>(ar);
    
        //  ... other code ...
    }
