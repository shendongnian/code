    [Serializable]
    public class TestPlugin : MarshalByRefObject, ITestPlugin
    {
        public void DoSomething()
        {
            //Console.WriteLine("\r\nTestPlugin:\r\n" + string.Join("\r\n", AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetName().Name)));
        }
    }
