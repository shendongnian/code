    [POST("First URL here")]
    public virtual object Post([FromBody]IDictionary<string, object> values)
    {
        //add new object to collection
    }
    [POST("Second URL here")]
    public virtual IEnumerable<object> Post([FromBody] IDictionary<string, object>[] array)
    {
        return array.Select(Post);
    }
