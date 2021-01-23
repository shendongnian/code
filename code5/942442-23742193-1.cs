    public interface IContext
    {
        string SomeVariable { get; }
        int SomethingElse { get; }
    }
    
    public void LogIn(string user, IContext loginContext) { ... }
    public class MyTestContext : IContext
    {
        private MyTestContext() { }
        // TODO make this a singleton?
        public static MyTestContext Instance { get { return new MyTestContext(); } }
        public string SomeVariable { get { return "abc"; } }
        public int SomethingElse { get { return 2; } }
    }
