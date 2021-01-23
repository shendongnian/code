    [Description("TestSource2")]
    public class TestData1 : ITest
    {
        public IEnumerator GetEnumerator()
        {
            yield return "123";
            yield return "456";
        }
    }
    [Description("TestSource1")]
    public class TestData2 : ITest
    {
        public IEnumerator GetEnumerator()
        {
            yield return 33;
            yield return 44;
        }
    }
    public class TestDataProviderFixture
    {
        [Datapoints] 
        public string[] SourceNames = {"TestSource1", "TestSource2"};
        [Theory]
        public void TestTestDataProvider(string sourceName)
        {
            var provider = new TestDataProvider();
            var data = provider.GetEnumerator(sourceName);
            if (sourceName == "TestSource1")
            {
                while (data.MoveNext())
                {
                    //Do Stuff
                }
            }
            else if (sourceName == "TestSource2")
            {
                while (data.MoveNext())
                {
                //Do Stuff
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
