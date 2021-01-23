    [Route("test/void")]
    public void GetFirst()
    {
        StringBuilder stringbuilder = new StringBuilder();
        for (int i = 0; i < 20; i++)
        {
            stringbuilder.Append("something");
        }
        //Thread.Sleep(1000);
    }
    
    [Route("test/IHttpActionResult")]
    public IHttpActionResult GetSecond()
    {
        StringBuilder stringbuilder = new StringBuilder();
        for (int i = 0; i < 20; i++)
        {
            stringbuilder.Append("something");
        }
        //Thread.Sleep(1000);
        return Ok();
    }
