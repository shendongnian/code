    [TestMethod]
    public void TestInvertedIndicesSearch()
    {
        var words = new List<string>() { "Cow", "Horse" };
        var invertedIndices = new List<Index>()
        {
            new Index { word = "Pig", referenceIDs = new List<int>() { 1, 2, 8 }},
            new Index { word = "Chicken", referenceIDs = new List<int>() { 4, 8 }},
            new Index { word = "Horse", referenceIDs = new List<int>() { 1, 2, 8 }},
            new Index { word = "Goat", referenceIDs = new List<int>() { 3 }},
            new Index { word = "Cow", referenceIDs = new List<int>() { 1, 3 }}
            new Index { word = "Coward", referenceIDs = new List<int>() { 999 }}
        };
        
        // Contains is searching for x.word _in the list_ "words", not searching
        // to see if any of the _strings within words_ contains x.word.
        var final = invertedIndices.Where(x => words.Contains(x.word))
                                   .SelectMany(y => y.referenceIDs)
                                   .Distinct();
    
        Assert.AreEqual(4, final.Count(), "result count");
        Assert.IsTrue(final.Contains(1), "missing 1");
        Assert.IsTrue(final.Contains(3), "missing 3");
        Assert.IsTrue(final.Contains(2), "missing 2");
        Assert.IsTrue(final.Contains(8), "missing 8");
        // already found the 4 matches, do not need to prove that 999 is absent.
    }
