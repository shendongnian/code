    [HttpPost]
    public HttpResponseMessage OpenSession(OpenSessionParameters parameters)
    {
        //Logic of post in here never gets hit
    }
    
    public class OpenSessionParameters
    {
        public int Id { get; set; }
    }
