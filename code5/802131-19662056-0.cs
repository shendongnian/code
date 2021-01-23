    public interface IContract { void Method(); }
    public class Backend : IContract { public void Method(); }
    public class Frontend
    {
        public IContract Contract { get; set; }
 
        public Frontend(IContract contract)
        {
            Contract = contract;
        }
        public void DoSomething()
        {
            Contract.Method();
        }
    }
