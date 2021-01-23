    public interface ISelection<out T>
    {
        T Skip(int n);
        T Method2();
        T Method3();
    }
    public interface IDateTimeSelection<out T> : ISelection<T>
    {
        T SpecialMethod();
    }
    public class Implementation : IDateTimeSelection<Implementation>
    {
        public Implementation Skip(int n)
        {
            return this;
        }
        public Implementation Method2()
        {
            return this;
        }
        public Implementation Method3()
        {
            return this;
        }
        public Implementation SpecialMethod()
        {
            return this;
        }
    }
