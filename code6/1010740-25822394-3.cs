            var list = new[] { 1, -1, 4, 5, 6, -10, -2, -5 };
            var permutations = list.ToList().PowerSet(); // Get Power Set
            var zeros = permutations.Where(i => i.Sum() == 0)                   // Locate all whose sum adds to zero
                                            .OrderByDescending(i => i.Count())  // Order by number of items
                                            .Where(i => i.Count() > 0);         // Exclude the empty set
            if (!zeros.Any())
            {
                Console.WriteLine("No zero subset.");
            }
            else
            {
                foreach (var item in zeros)
                {
                    Console.WriteLine(string.Format("{0} = 0", string.Join(" + ", item.OrderBy(i=>i))));
                }
            }
