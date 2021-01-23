    class RandomNumbers
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            var numbers = GenerateRandomNumbers(200,100,10);
            foreach (var temp in numbers)
            {
                Console.Write(temp+" ");
            }
        }
        static IEnumerable<int> GenerateRandomNumbers(int NumberOfElements)
        {
            return Enumerable.Range(0,NumberOfElements-1).OrderBy(n=>random.Next());
        }
        static IEnumerable<int> GenerateRandomNumbers(int min, int max, int numberOfElement)
        {
            return Enumerable.Range(0, numberOfElement - 1).Select(n => random.Next(max, min));
        }
    }
