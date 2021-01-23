    [Serializable]
    public class UserMessage
    {
        public MethodArguments MethodArguments { get; set; }
        public string MethodName { get; set; }
    }
    public class MethodArguments
    {
        public Entry Entry { get; set; }
    }
    public class Entry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
