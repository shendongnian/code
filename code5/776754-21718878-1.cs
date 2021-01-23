    public class LoadTestIteration : ILoadTestPlugin
    {
        List<int> usedTestIterationNumbers = new List<int>();
        public void Initialize(LoadTest loadTest)
        {
            loadTest.TestStarting += (sender, e) =>
            {
                e.TestContextProperties["$LoadTest.TestIterationNumber"] = e.TestIterationNumber;
                System.Diagnostics.Debug.Assert(!usedTestIterationNumbers.Contains(e.TestIterationNumber), "Duplicate LoadTest TestIterationNumber: " + e.TestIterationNumber);
                usedTestIterationNumbers.Add(e.TestIterationNumber);
            };
        }
    }
    public class TestWebTestIteration : WebTestPlugin
    {
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            int lti = (int)e.WebTest.Context["$LoadTest.TestIterationNumber"];
            int wti = e.WebTest.Context.WebTestIteration;
            System.Diagnostics.Debug.Assert(lti == wti, String.Format("$LoadTestIteration {0} differs from $WebTestIteration {1}", lti, wti));
        }
    }
