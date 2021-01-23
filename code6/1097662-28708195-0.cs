    public static class RandomExtensions {
        public static IEnumerable<int> NextInt32s(this System.Random random, int neededValuesNumber, int minInclusive, int maxExclusive) { /* ... */ }
    }
    public class RandomExtensionsTests {
        [Test]
        public void Select()
        {
            const int min = 0, max = 10;
            var randomizer = Substitute.For<Random>();
            randomizer.Next(min, max).Returns(1, 2, 3);
            var result = randomizer.NextInt32s(3, 0, 10).ToArray();
            Assert.AreEqual(new[] {1, 2, 3}, result);
        }
    }
