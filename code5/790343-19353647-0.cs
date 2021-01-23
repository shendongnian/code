    public class HelloResponse 
    {
        public HelloResponse() 
        {
            this.Pong = "(nothing comes back!)";
        }
    
        public ResponseStatus ResponseStatus { get; set; }
        public string Pong { get; set; }
    }
