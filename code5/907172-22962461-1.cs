    [HttpGet]
    [Route("")]
    [Route("{name}/{drink}/{sport?}")]
    public List<int> Get(string name, string drink, string sport = "")
    {
        // Code removed...
    }
