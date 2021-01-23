    static void Main(string[] args)
    {
        foreach (var num in GetMod11Sequence(10000000, 100000000).Take(100))
        {
            if (!CheckMod11CheckChar(num))
            {
                throw new InvalidOperationException();
            }
            else
            {
                Console.WriteLine(num);
            }
        }
    }
    private static IEnumerable<string> GetMod11Sequence(int start, int stop)
    {
        //Contract.Requires(start > 0);
        //Contract.Requires(stop > start);
        //Contract.Requires(stop < 1000000000);
        for (int c = start; c < stop; c++)
        {
            string number = c.ToString();
            char check;
            if (TryCalculateMod11CheckChar(number, out check))
            {
                yield return number + check;
            }
        }
    }
    private static bool CheckMod11CheckChar(string number)
    {
        //Contract.Requires(number != null);
        //Contract.Requires(number.All(c => char.IsDigit(c)));
        int factor = number.Length;
        int sum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            int cval = number[i] - '0';
            sum += cval * factor;
            factor--;
        }
        return sum % 11 == 0;
    }
    private static bool TryCalculateMod11CheckChar(string number, out char checkDigit)
    {
        //Contract.Requires(number != null);
        int factor = number.Length + 1;
        int sum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            int cval = number[i] - '0';
            sum += cval * factor;
            factor--;
        }
        //Contract.Assert(factor == 1);
        int delta = sum % 11;
        if (delta == 1)
        {
            // I cannot add 10, so this number is unavailable
            checkDigit = '!';
            return false;
        }
        else
        {
            if (delta == 0)
            {
                checkDigit = '0';
            }
            else
            {
                checkDigit = (11 - delta).ToString()[0];
            }
            return true;
        }
    }
