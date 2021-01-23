    class Program
    {
        static void Main(string[] args)
        {
            var Pattern = new List<string>() { "a", "b", "c" };
            Combinator<string> Combinator = new Combinator<string>(Pattern);
            while (Combinator.HasFinised == false)
            {
                var Combined = Combinator.Next();
                var Joined = string.Join("-", Combined);
                Console.WriteLine(Joined);
            }
            Console.ReadKey();
        }
    }
