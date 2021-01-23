    public interface ITestA { }
    public interface ITestB { }
    public abstract class Test<T> {
        internal Test() { }
    }
    public class Test1<T> : Test<T> where T : ITestA { }
    public class Test2<T> : Test<T> where T : ITestB { }
