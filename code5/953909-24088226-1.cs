    class DestroyHelper<T>
    {
        static readonly Action<int> _destroy;
        static readonly Func<T, int> _getId;
        static DestroyHelper()
        {
            var destroyMethod = typeof(T).GetMethod("Destroy", BindingFlags.Static | BindingFlags.Public);
            _destroy = (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), destroyMethod);
            var getIdMethod = typeof(T).GetProperty("Id").GetGetMethod();
            _getId = (Func<T, int>)Delegate.CreateDelegate(typeof(Func<T, int>), getIdMethod);
        }
        
        public static void Destroy(T element)
        {
            _destroy(_getId(element));
        }
    }
