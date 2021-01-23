        private static void FillNumbers(ref List<int> numbers)
        {
            for (int i = 0; i < 333; i++)
            {
                int n = Rnd.Next(1, 101);
                numbers.Add(n);             
            }
            numbers = numbers.Distinct().ToList();
            Console.WriteLine("After distinct there are {0} numbers in the list",numbers.Count);
        }
