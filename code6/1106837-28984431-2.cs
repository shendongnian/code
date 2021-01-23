    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 2, 3, 4, 5, 6 })]   // PASS
    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 3, 5 })]            // PASS
    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 3, 3, 5 })]         // PASS
    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 2, 4, 5 })]         // FAIL
    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 5, 3 })]            // FAIL
    [TestCase(new[] { 1, 3, 5 }, new[] { 1, 5, 3, 5 })]         // PASS
    public void TestSubsequnce(IEnumerable<int> subsequence, IEnumerable<int> supersequence)
    {
        AssertSubsequenceWithGaps(subsequence, supersequence);
    }
    
    public static void AssertSubsequenceWithGaps(IEnumerable<int> subsequence, IEnumerable<int> supersequence)
    {
        // iterating multiple times, cast sequences to List
        var listSub = subsequence.ToList();
        var listSuper = supersequence.ToList();
    
        int expected = listSub.Count;
        int innerPointer = 0;
        int actual = 0;
        for (int i = 0; i < listSub.Count; i++)
        {
            for ( /* start from where we left before */; innerPointer < listSuper.Count; innerPointer++)
            {
                var valueSub = listSub[i];
                var valueSuper = listSuper[innerPointer];
                if (valueSub == valueSuper)
                {
                    actual++;
                    break;
                }
            }
        }
    
        Assert.AreEqual(expected, actual);
    }
