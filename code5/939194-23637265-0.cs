    // POST api/<controller>
    public HttpResponseMessage Post([FromBody]string value)
    {
        new System.Threading.Tasks.Task(() =>
        {
            //insert to db code;
        }).Start();
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
