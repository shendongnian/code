    interface ISomething
    {
        string Name;
    }
    class MySomething : ISomething
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class MySomethingElse : ISomething
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
