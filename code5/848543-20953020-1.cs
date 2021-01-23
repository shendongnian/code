        char[] items = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        for (int length = 2; length <= 4; length++)
        {
            foreach (IEnumerable<char> permutation in PermuteUtils.Permute(items, length))
            {
                StringBuilder output = new StringBuilder("0x");
                foreach (char c in permutation)
                {
                    output.Append(c);
                }
                Console.WriteLine(output.ToString());
            }
        }
        Console.WriteLine("Done");
        Console.ReadLine();
    }
