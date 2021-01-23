    public class Question
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; }
    }
    public class Option
    {
        public int Id { get; set; }
        public string Response { get; set; }
    }
