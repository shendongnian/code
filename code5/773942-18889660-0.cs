    public interface IStrategy
    {
        ComplexReturnType MyMethod();
    }
    public class NationalDefaultStrategy : IStrategy
    {
        public ComplexReturnType MyMethod() { }
    }
    public class BostonStrategy: IStrategy
    {
        public ComplexReturnType MyMethod() { }
    }
    public class MyClass
    {
        private static IStrategy _strategy = new NationalDefaultStrategy();
        public static ISTrategy Strategy { get {...}; set {...} }
        public static ComplexReturnType MyMethod()
        {
            return _strategy.MyMethod();
        }
    }
