    // Route 1
    [Route("/getplayernamechanged", "POST")]
    public class ChangePlayerNameRequest : IReturn<PlayerResponse>
    {
        public string Name { get; set; }
    }
    // Route 2
    [Route("/getplayernamechanged2", "POST")]
    public class ChangePlayerNameAndConcatRequest : IReturn<PlayerResponse>
    {
        public string Name { get; set; }
    }
    public class PlayerResponse
    {
        public string Name { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
