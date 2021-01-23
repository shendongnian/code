    class Program
    {
        static void Main(string[] args)
        {
            int number, cntOfElements;
            int.TryParse(Console.ReadLine(), out number);
            int.TryParse(Console.ReadLine(), out cntOfElements);
            int[] intArray = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).Distinct().ToArray();
            bool hasMatchingSubs = false;
            //The amount of possible combinations are 2 of power - the count of integers in the array
            //if they (the numbers) are 3 the combinations with the zero are 8 (in binary 0000 1000)
            //so we have 3 numbers and the bits before the setted bit of the 8 are the same count
            //this means that we can use them to get all the unique combinations for that amount of numbers 
            //7 combinations without the zero (in binary 0000 0111).
            int combos = (int)Math.Pow(2, intArray.Length);
            List<List<int>> result = new List<List<int>>();
    
            //we cicle around all the possible combinations
            for (int mask = 1; mask < combos; mask++)
            {
                int sum = 0;
                List<int> list = new List<int>();
                //In the second for construction when the corresponding bit is set wi add this value
                //to the sum for this combination and when the bit is 0 we skip the adding
                for (int idx = 0; idx < intArray.Length; idx++)
                {
                    if ((mask >> idx & 1) == 1)
                    {
                        sum += intArray[(intArray.Length - 1) - idx];
                        list.Add(intArray[(intArray.Length - 1) - idx]);
                    }
                }
    
                //We are checking the sum for this combination before the next one
                if (sum == number && list.Count() == cntOfElements)
                {
                    hasMatchingSubs = true;
                    result.Add(list);
                }
            }
    
            if (!hasMatchingSubs)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                result.ForEach(p => p.Sort()); //Sorting all elements in the inner lists
                result = result.OrderBy(a => a.Count).ThenBy(b => b.First()).ToList();  //ordering by the count of items in each list
                                                                                        //and than by the value of the sirst integer
                result.ForEach(p => Console.WriteLine("{0} = {1}", string.Join(" + ", p), number));
            }
        }
    }
