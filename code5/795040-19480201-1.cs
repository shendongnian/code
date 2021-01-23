    [TestFixture]
    public class TestClass
    {
        private static readonly object[] _sourceLists = {new object[] {new List<int> {1}},  //case 1
                                         new object[] {new List<int> {1, 2}} //case 2
                                        };
    
        [Test, TestCaseSource("_sourceLists")]
        public void Test(List<int> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
