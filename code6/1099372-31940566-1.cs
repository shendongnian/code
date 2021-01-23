    using Xunit;
    using Xunit.Abstractions;
    namespace xUnitTestOutput
    {
        public class OutputTests
        {
            private readonly ITestOutputHelper _output;
            public OutputTests(ITestOutputHelper output)
            {
                _output = output;
            }
            [Fact]
            public void FirstOutputTest()
            {
                _output.WriteLine("This is output from the test!");
            }
        }
    }
