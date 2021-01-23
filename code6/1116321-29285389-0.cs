    private static bool IsPalindromeAnagram(string test)
    {
        var charCount = test.GroupBy(c => c, (c, i) => new
            {
                character = c,
                count = i.Count()
            });
        return charCount.Count(c => c.count % 2 == 1) <= 1;
    }
