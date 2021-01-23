    [TestClass]
    public class TestBase
    {
        static TestBase()
        {
            s_log = new StringBuilder();
            Log.AppendLine("TestBase.ctor()");
        }
    
        [TestInitialize]
        public void BaseTestInit()
        {
            Log.AppendLine("TestBase.BaseTestInit()");
        }
    
        [TestCleanup]
        public void BaseTestCleanup()
        {
            Console.WriteLine(Log.ToString());
        }
    
        public static StringBuilder Log
        {
            get { return s_log; }
        }
    
        static StringBuilder s_log;
    } 
