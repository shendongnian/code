    class Program
    {
        static void Main( string[] args )
        {
            ITest x = new TestClass();
            Console.WriteLine( x.GetTypeArgTypeFrom( new BaseClass<int>() ) );
            Console.ReadKey();
        }
    }
    public class BaseClass<T>
    {
        public Type GetTypeArgType()
        {
            return typeof( T );
        }
    }
    public interface ITest
    {
        Type GetTypeArgTypeFrom<T>( BaseClass<T> bct );
    }
    public class TestClass : ITest
    {
        public Type GetTypeArgTypeFrom<T>( BaseClass<T> bct )
        {
            return bct.GetTypeArgType();
        }
    }
