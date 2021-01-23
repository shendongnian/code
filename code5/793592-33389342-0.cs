    static void Main(string[] args)
        {
            const int target = 20;
            var numbers = new List<int> { 1, 2, 5, 8, 12, 14, 9 };
            Console.WriteLine($"Number of Combinations: {SumCounter(numbers, target)}");
            Console.ReadKey();
        }
       
        private static int SumCounter(IReadOnlyList<int> numbers, int target)
        {
            var result = 0;
            RecursiveCounter(numbers, target, new List<int>(), ref result);
            return result;
        }
        private static void RecursiveCounter(IReadOnlyList<int> numbers, int target, List<int> partial, ref int result)
        {
            var sum = partial.Sum();
            if (sum == target)
            {
                result++;
                Console.WriteLine(string.Join(" + ", partial.ToArray()) + " = " + target);
            }
            if (sum >= target) return;
            for (var i = 0; i < numbers.Count; i++)
            {
                var remaining = new List<int>();
                for (var j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);
                var partRec = new List<int>(partial) { numbers[i] };
                RecursiveCounter(remaining, target, partRec, ref result);
            }
        }
