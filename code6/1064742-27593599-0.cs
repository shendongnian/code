    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void Test()
        {
            var dictionary = new Dictionary<Tuple<int, int>, string>
                             {
                                 {Tuple.Create(2, 134), "Value 1"},
                                 {Tuple.Create(21, 34), "Value 2"},
                                 {Tuple.Create(213, 4), "Value 3"},
                             };
            dictionary.ContainsKey(Tuple.Create(21, 34)).Should().BeTrue();
            dictionary.ContainsKey(Tuple.Create(213, 4)).Should().BeTrue();
            dictionary.ContainsKey(Tuple.Create(0, 0)).Should().BeFalse();
        }
    }
