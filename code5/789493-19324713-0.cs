    public class Command<T> where T : Box
    {
        public string name;
        public string num;
        public T PARAMS { get; set; }
    }
