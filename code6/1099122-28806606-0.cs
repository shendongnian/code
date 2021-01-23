    public interface IConnectionManagerFactory<out T>
            where T : IConnectionManager
    {
        void Do1(T t); // not valid 
        T Do2();       // valid
    }
