    public class Response
    {
        public Response()
        {
            this.Tags = new List<TAG>();
        }
        public List<TAG> Tags { get; set; }
    }
    public class TAG
    {
        public string Tagid { get; set; }
        public string Mac { get; set; }
    }
