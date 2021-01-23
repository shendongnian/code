    class Program
    {
        static void Main(string[] args)
        {
            MultiplyFactors(new List<ulong>() { 2, 3, 5, 7 });
            Console.ReadLine();
        }
        public static void MultiplyFactors(List<ulong> numbers)
        {
            var factorCombinations = CreateSubsets(numbers.ToArray());
            foreach (var factors in factorCombinations)
            {
                // set initial result to identity value. (any number multiplied by itself is 1)
                ulong result = 1;
                // multiply all factors in combination together
                for (int i = 0; i < factors.Count(); i++)
                {
                    result *= factors[i];
                }
                // Output for Display
                Console.WriteLine(String.Format("{0}={1}", String.Join("x", factors), result));
                
            }
        }
        private static List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            // From http://stackoverflow.com/questions/3319586/getting-all-possible-permutations-from-a-list-of-numbers
            var subsets = new List<T[]>();
            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] {originalArray[i]});
                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }
            return subsets;
        }
    }
