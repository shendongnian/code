    class People
    {
        public string Name { get; set; }
        public People()
        {
            Name = "Billy";
        }
        public People(string name)
        {
            Name = name;
        }
        public string CallMe()
        {
            return Name;
        }
        public string CallMe(string value)
        {
            return value;
        }
        public void NoReturn()
        {
            Console.WriteLine("nothing");
        }
    }
