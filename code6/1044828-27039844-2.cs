    public class CustomTestCase
    {
        public CustomTestCase(int SearchNumber, List<int> List, int Result)
        {
            searchNumber = SearchNumber;
            list = List;
            result = Result;
        }
        private int searchNumber;
        private List<int> list;
        private int result;
        public string TestName()
        {
            return string.Format("TestChop({0},{{{1}}})", searchNumber, String.Join(",", list));
        }
        public TestCaseData SimpleTest()
        {
            return new TestCaseData(searchNumber, list).Returns(result).SetName(this.TestName());
        }
    }
