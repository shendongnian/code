    [TestFixture]
    public class SampleTests
    {
        [TestCaseSource("TestData")]
        public void Test(CallTracker callTracker)
        {
            callTracker.Call++;
            callTracker.Call++;
        }
        public IEnumerable TestData()
        {
            yield return new TestCaseData(new CallTracker());
        }
        public class CallTracker
        {
            int call;
            public int Call
            {
                get
                {
                    return call;
                }
                set
                {
                    call = value;
                    Console.WriteLine(call);
                }
            }
        }
    }
