    public interface IBase { }
    public interface ITestA : TestBase { }
    public interface ITestB : TestBase { }
    public class Test<T> where T : IBase {
    }
