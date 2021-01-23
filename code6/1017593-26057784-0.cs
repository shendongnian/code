    public class ReadWriteTest : ITest<IAction>
    {
        public List<IAction> Actions { get; set; }
    }
    
    public class ReadTest : ITest<ReadAction>
    {
        public List<ReadAction> Actions { get; set; }
    }
