       [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall,ConcurrencyMode=ConcurrencyMode.Single)]
    public class TestServiceWithStaticVars : ITestServiceWithStaticVars
    {
       static int instanceCount = 0;
        public TestServiceWithStaticVars()
        {
            Interlocked.Decrement(ref instanceCount);
        }
        public string GetInstanceCount()
        {
            return string.Format("You have created {0} instance", instanceCount);
        }
