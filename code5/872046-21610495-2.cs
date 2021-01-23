    public interface IBase { }
    public interface ITestA : IBase { }
    public interface ITestB : IBase { }
    public abstract class Test<T> where T : IBase {
        internal Test() { }
    }
    public class Test1<T> : Test<T> where T : ITestA { }
    public class Test2<T> : Test<T> where T : ITestB { }
