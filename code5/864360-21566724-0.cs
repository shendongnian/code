    public string Postsam([FromBody]object jsonData)
    {
        IEnumerable<string> headerValues;
            
        if (Request.Headers.TryGetValues("Custom", out headerValues))
        {
            string token = headerValues.First();
        }
    }   
