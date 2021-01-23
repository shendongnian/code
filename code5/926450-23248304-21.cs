        static void Main(string[] args)
        {
            Combinator<int> Combinator = new Combinator<int>(new List<int>() { 1, 2, 3 });
            while (Combinator.HasFinised == false)
            {
                var NextCombination = Combinator.Next();
                var DistinctCheck = NextCombination.ToList().Distinct();
                if (DistinctCheck.Count() == NextCombination.Count())
                {
                    Console.WriteLine(string.Join(String.Empty, NextCombination.Select(Item => Item.ToString())));
                }                
            }
            Console.ReadKey();
        }
