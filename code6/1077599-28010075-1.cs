    public IEnumerable<int> BANS()
    {
        int[] digits = {1, 0, 0, 0, 0, 0, 0, 0, 2};
        readonly int[] multipliers = {9, 8, 7, 6, 5, 4, 3, 2, 1};
        int carryFlag = 0;
        do
        {
            int sum = digits.Zip(multipliers, (d, m) => d * m)
                            .Sum();
            if (sum % 11 == 0)
                yield return sum;
            int digitIndex = digits.Length - 1;
            do
            {
                digits[digitIndex] += 1 + carryFlag;
                if (digits[digitIndex] == 10)
                {
                    digits[digitIndex--] = 0;
                    carryFlag = 1;
                }
                else
                    carryFlag = 0;
            }
            while (carryFlag == 1 && digitIndex >= 0);
        }
        while (carryFlag == 0);
        yield break;
    }
    . . .
    var bansAsStrings = BANS.Take(100).Select(ban => ban.ToString());
