    public abstract class State
    {
        public static string[] operators = new string[] { "+", "-", "*", "/" };
        public List<string> Expressions { get; set; }
        public List<string> Tokens { get; set; }
        public abstract State Process(string token);
    }
