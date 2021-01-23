    private static List<string> PowerSet(string input)
    {
        int n = input.Length;
        // Power set contains 2^N subsets.
        /* NOTE 1 : This will work for sequence with at most 30 elements because 
           the literal 1 is Int32 signed data type and has only 32 bits to
           shift. A proper loop variant should be used to calculate 2^N for
           sequence having more elements. */
        int powerSetCount = 1 << n;
        var ans = new List<string>();
        for (int setMask = 0; setMask < powerSetCount; setMask++)
        {
            var s = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                // Checking whether i'th element of input collection should go to the current subset.
                if ((setMask & (1 << i)) > 0)
                {
                    s.Append(input[i]);
                }
            }
            ans.Add(s.ToString());
        }
        return ans;
    }
