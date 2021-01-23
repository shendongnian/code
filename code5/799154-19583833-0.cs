    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Hello {you,uyo,u}, whats {up,down}?";
            var random = new Random();
            var result = Regex.Replace(input, @"{.*?}", m =>
            {
                var values = m.Value.Substring(1, m.Value.Length - 2).Split(',');
                return values.ElementAt(random.Next(values.Length));
            });
            Console.WriteLine(result);
        }
    }
