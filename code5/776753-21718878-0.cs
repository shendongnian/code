    public class TestLoadTestPlugin : ILoadTestPlugin
    {
        public void Initialize(LoadTest loadTest)
        {
            loadTest.TestStarting += (sender, e) =>
            {
                e.TestContextProperties["$LoadTestIteration"] = e.TestIterationNumber;
            };
        }
    }
    public class TestWebTestPlugin : WebTestPlugin
    {
        int lastLti, lastWti;
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            int lti = (int)e.WebTest.Context["$LoadTestIteration"];
            int wti = e.WebTest.Context.WebTestIteration;
            System.Diagnostics.Debug.Assert(lti == wti, String.Format("$LoadTestIteration {0} differs from $WebTestIteration {1}", lti, wti));
            System.Diagnostics.Debug.Assert(lti > lastLti, "Duplicate LoadTestIteration number!");
            System.Diagnostics.Debug.Assert(wti > lastWti, "Duplicate WebTestIteration number!");
        }
    }
