    interface ITest<T>
    {
        T GetObject();
    }
    public class Test1 : ITest<Logger>
    {
        public Logger GetObject()
        {
            return new Logger();
        }
    }
