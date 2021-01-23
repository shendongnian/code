    class Program
    {
        static void Main(string[] args)
        {
            string s = "_8_12";
            Console.WriteLine("Original ==> \"{0}\"", s);
            Dictionary<string, int> numbers = ParseNumbers(s);
            PrintNumbers(numbers);
            s = "_1_19_7";
            Console.WriteLine("Original ==> \"{0}\"", s);
            numbers = ParseNumbers(s);
            PrintNumbers(numbers);
        }
        private static Dictionary<string, int> ParseNumbers(string s)
        {
            var variables = new Dictionary<string, int>();
            char startVar = 'i'; // Start at 'i' Variable
            string[] nums = s.Split('_');
            foreach (string num in nums)
            {
                if (string.IsNullOrWhiteSpace(num))
                    continue;
                variables.Add(startVar.ToString(CultureInfo.InvariantCulture), int.Parse(num));
                startVar++;
            }
            return variables;
        }
        private static void PrintNumbers(Dictionary<string, int> numbers)
        {
            foreach (var q in numbers)
            {
                Console.WriteLine("{0} ==> {1}", q.Key, q.Value);
            }
            Console.WriteLine();
        }
    }
