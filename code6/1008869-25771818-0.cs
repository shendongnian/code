    public class Parameter{
      public string apiKey{ get; set; }
      public string userId{ get; set; }
      public string message{ get; set; }
    }
    [Route( "Data/Message/" )] 
    [HttpPost]
    public Message Post(Parameter yourParam)
    {
    }
