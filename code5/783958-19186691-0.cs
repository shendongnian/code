    [Route("/prefix/{Param1}", "POST")]
    public class SomeRequest : List<SomeEntry>
    {
        public string          Param1  { get; set; }
    }
