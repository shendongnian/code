    public class Facade
    {
        public Transaction GetTransaction<T>() where T : Transaction
        {
            // any other process
            return (T)result;
        }
    }
