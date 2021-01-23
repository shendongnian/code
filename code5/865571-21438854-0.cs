    public class StuffCreateRequest
    {
        public string Name { get; set; }
        public StuffCreateRequestStep[] Steps { get; set; }
    }
    public class StuffCreateRequestStep
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }
