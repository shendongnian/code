    public class ClassToTest
    {
        private readonly Func<DateTime> _nowProvider;
        public ClassToTest(Func<DateTime> nowProvider)
        {
            _nowProvider = nowProvider;
        }
        public ClassToTest()
        {
            _nowProvider = () => DateTime.Now;
        }
        //snip
    }
