    class Program
    {
        static void Main(string[] args)
        {
            string test = "ABStreet 10 552896";
            test = Regex.Replace(test, @"\s\d*$",string.Empty);
            Console.WriteLine(test);
        }
    }
