    public abstract class Bank
    {
        public enum EType { Int, Gm, User };
    }
    
    public abstract class Bank<T> : Bank
    {
    }
