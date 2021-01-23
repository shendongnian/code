    using System.Linq;
    [TestClass]
    public class SelectFixture {
        private static int Parse(string str) {
            return int.Parse(str);
        }
        [TestMethod]
        public void MapStringsToInts() {
            var expected = new[] {1, 2, 3, 4, 5};
            var strings = new List<string> { "1", "2", "3", "4", "5" };
            var numbers = strings.Select(Parse).ToList();
            CollectionAssert.AreEquivalent(expected, numbers);
        }
    }
