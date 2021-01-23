    public static IEnumerable<int> BANS
    {
        get
        {
            int[] digits = { 1, 0, 0, 0, 0, 0, 0, 0, 2 };
            int carryFlag = 0;
            do
            {
                int sum = digits.Select((d, i) => d * (9 - i))
                                .Sum();
                if (sum % 11 == 0)
                    yield return digits.Aggregate(0, (accumulator, digit) => accumulator * 10 + digit);
                int digitIndex = digits.Length - 1;
                do
                {
                    digits[digitIndex] += 1;
                    if (digits[digitIndex] == 10)
                    {
                        digits[digitIndex--] = 0;
                        carryFlag = 1;
                    }
                    else
                        carryFlag = 0;
                }
                while (digitIndex >= 0 && carryFlag == 1);
            }
            while (carryFlag == 0);
            yield break;
        }
    }
