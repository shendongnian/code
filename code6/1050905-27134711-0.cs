    [TestFixture]
    public class tester
    {
        [TestCase("test.doc", 1, 3)]
        [TestCase("test.doc", 1, 3, 4, 5, 6)]
        public void test(string filename, int totalObjects, params int[] objectsToTest)
        {
        }
    }
