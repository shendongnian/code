    public class Foo
    {
        private Dictionary<Type, Delegate> dictionary =
            new Dictionary<Type, Delegate>();
        public Func<T, int> GetLambdaFor<T>()
        {
            return dictionary[typeof(T)] as Func<T, int>;
        }
        public void SetLambdaFor<T>(Func<T, int> func)
        {
            dictionary[typeof(T)] = func;
        }
    }
