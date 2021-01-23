    public interface TestBase { }
    public interface TestA : TestBase { }
    public interface TestB : TestBase { }
    public class Test<T> where T : TestBase
    {
    
    }
