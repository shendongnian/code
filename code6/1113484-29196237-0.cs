    class Program
    {
        static void Main()
        {
            Example e = new Example();
            e.Name = "Hello World";
            var x = e.Name;
            var y = x.addTextToName();
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
    class Example
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    public static class MyExtensions
    {
        public static string addTextToName(this string str)
        {
            return str += " - Test";
        }
    }
