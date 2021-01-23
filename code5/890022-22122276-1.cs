    [HttpGet]
    [Route("api/{controller}/special")]
    public IEnumerable<string> SpecialValues()
    {
        return new string[] { "special1", "special2" };
    }
