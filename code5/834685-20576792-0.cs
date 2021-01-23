    // Determines whether an int is greater than zero
    public class GreaterThanZeroTest : ITest
    {
        public int SomeTestVariable { get; set; }
        public bool SomeTestMethod()
        {
            return SomeTestVariable > 0;
        }
    }
    // Determines whether an int is less than zero
    public class LessThanZeroTest : ITest
    {
        public int SomeTestVariable { get; set; }
        public bool SomeTestMethod()
        {
            return SomeTestVariable < 0;
        }
    }
