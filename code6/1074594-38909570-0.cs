    public class Person : Tuple<string, string>
    {
        public Key(string name, string age) : base(name, age) { }
        public string Name => Item1;
        public string Age => Item2;
    }
