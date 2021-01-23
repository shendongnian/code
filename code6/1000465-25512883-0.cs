    [HttpGet]
    public object IsCodeValid(string code)
    {
        return new { result: db.Usagers.Any(u => u.CodeAcces == code) };
    }
