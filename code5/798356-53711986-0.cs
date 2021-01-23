    public static void AssertListEquals<TE, TA>(Action<TE, TA> asserter, IEnumerable<TE> expected, IEnumerable<TA> actual)
    {
        IList<TA> actualList = actual.ToList();
        IList<TE> expectedList = expected.ToList();
    
        Assert.True(
            actualList.Count == expectedList.Count,
            $"Lists have different sizes. Expected list: {expectedList.Count}, actual list: {actualList.Count}");
    
        for (var i = 0; i < expectedList.Count; i++)
        {
            try
            {
                asserter.Invoke(expectedList[i], actualList[i]);
            }
            catch (Exception e)
            {
                Assert.True(false, $"Assertion failed because: {e.Message}");
            }
        }
    }
