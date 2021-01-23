    public class StringTests2
    {
        [Theory, PropertyData("SplitCountData")]
        public void SplitCount(string input, int expectedCount)
        {
            var actualCount = input.Split(' ').Count();
            Assert.Equal(expectedCount, actualCount);
        }
     
        public static IEnumerable<object[]> SplitCountData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                    new object[] { "xUnit", 1 },
                    new object[] { "is fun", 2 },
                    new object[] { "to test with", 3 }
                };
            }
        }
    }
