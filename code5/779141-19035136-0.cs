    public class Generic<T> where T : M
    {
        public virtual String foo(T n)
        {
            return "I don't want this generic foo for M";
        }
    }
