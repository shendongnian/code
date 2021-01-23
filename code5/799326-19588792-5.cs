    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var array = new[,] { { 1, 2 }, { 3, 4 }, { 1, 2 }, { 7, 8 } };
            array = array.ToEnumerableOfEnumerable()
                         .Distinct(new ListEqualityComparer<int>())
                         .ToList()
                         .ToTwoDimensionalArray();
        }
    }
