    public class Rule
    {
        public string Condition { get; set; }
        public List<Rule> Rules { get; set; }
        public string Id { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }
        public string Input { get; set; }
        public string Operator { get; set; }
        public List<string> Value { get; set; }
    }
