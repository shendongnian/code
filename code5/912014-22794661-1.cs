    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                CheckIfNumeric("A");
                CheckIfNumeric("22");
                CheckIfNumeric("Potato");
                CheckIfNumeric("Q");
                CheckIfNumeric("A&^*^");
                Console.ReadLine();
            }
            private static void CheckIfNumeric(string input)
            {
                if (input.IsNumeric())
                {
                    Console.WriteLine(input + " is numeric.");
                }
                else
                {
                    Console.WriteLine(input + " is NOT numeric.");
                }
            }
        }
        public static class StringExtensions
        {
            public static bool IsNumeric(this string input)
            {
                return Regex.IsMatch(input, @"^\d+$");
            }
        }
    }
