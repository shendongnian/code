    int[] PickIntegers(int amountToPick, int maxSize)
    {
        List<int> numbers = new List<int>(amountToPick);
    
        for (int x = 0; x < amountToPick; x++)
        {
            int n = 0;
            while (true)
            {
                n = r.Next(0, maxSize);
                if (!numbers.Contains(n))
                {
                    numbers.Add(n);
                    break;
                }
            }
        }
    
        return numbers.ToArray();
    }
