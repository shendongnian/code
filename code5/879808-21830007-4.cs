    public class Person
    {
        public string Name { get; set; }
    }
    // Route 1
    [Route("/getplayernamechanged", "POST")]
    public class ChangePlayerNameRequest : Player, IReturn<PlayerResponse>
    {
    }
    // Route 2
    [Route("/getplayernamechanged2", "POST")]
    public class ChangePlayerNameAndConcatRequest : Player, IReturn<PlayerResponse>
    {
    }
