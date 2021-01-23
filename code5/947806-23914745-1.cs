    var words = new List<string>() { "Cow", "Horse" };
    var invertedIndices = new List<Index>()
    {
        new Index { word = "Pig", referenceIDs = new List<int>() { 1, 2, 8 }},
        new Index { word = "Chicken", referenceIDs = new List<int>() { 4, 8 }},
        new Index { word = "Horse", referenceIDs = new List<int>() { 1, 2, 8 }},
        new Index { word = "Goat", referenceIDs = new List<int>() { 3 }},
        new Index { word = "Cow", referenceIDs = new List<int>() { 1, 3 }}
    };
    
    var final = invertedIndices.Where(x => words.Contains(x.word))
                               .SelectMany(y => y.referenceIDs)
                               .Distinct();
    
    Assert.AreEqual(4, final.Count(), "result count");
    Assert.IsTrue(final.Contains(1), "missing 1");
    Assert.IsTrue(final.Contains(3), "missing 3");
    Assert.IsTrue(final.Contains(2), "missing 2");
    Assert.IsTrue(final.Contains(8), "missing 8");
