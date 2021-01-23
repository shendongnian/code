    private string[] inputs = new string[]
    {
        "name:john",
        "surname:michael",
        "gender:boy",
        "name:pete",
        "title:captain",
    };
    private string[] expected = new string[]
    {
        "surname:michael",
        "gender:boy",
        "name:pete",
        "title:captain",
    };
    private static List<string> FilterList(IEnumerable<string> src) {
        return src.Select(s =>
        {
            var pieces = s.Split(':');
            return new {Name = pieces[0], Value = pieces[1]};
        }).GroupBy(m => m.Name)
          .Select(g => String.Format("{0}:{1}", g.Key, g.Last().Value)).ToList();;
			
    }
    [TestMethod]
    public void TestFilter() {
        var actual = FilterList(inputs);
        CollectionAssert.AreEquivalent(expected, actual);
    }
