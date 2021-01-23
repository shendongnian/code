    [HttpPost]
    public HttpResponseMessage PostData([FromBody] string text)
    {
       // log text.
        DataModel data = JsonConvert.DeSerialize<DataModel>(text);
    }
