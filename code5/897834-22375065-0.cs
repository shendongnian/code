    public class foo:  TechTalk.SpecFlow.Tracing.ITraceListener
    {
        public void WriteTestOutput(string message)
        {
            EventLog.WriteEntry("mysource", "output: " + message);
        }
        public void WriteToolOutput(string message)
        {
            EventLog.WriteEntry("mysource", "specflow: " + message);
        }
    }
