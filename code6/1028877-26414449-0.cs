    class Program
    {
        class Guardable<T>
        {
            public T Value { get; private set; }
    
            private sealed class GuardHolder<TGuardable> : IDisposable where TGuardable : Guardable<T>
            {
                private readonly TGuardable _guardable;
                private readonly T _originalValue;
        
                public GuardHolder(TGuardable guardable)
                {
                    _guardable = guardable;
                    _originalValue = guardable.Value;
                }
                public void Dispose()
                {
                    _guardable.Value = _originalValue;
                }
            }    
    
            public Guardable(T value)
            {
                Value = value;
            }
            public IDisposable Guard(T newValue)
            {
                GuardHolder<Guardable<T>> guard = new GuardHolder<Guardable<T>>(this);
                Value = newValue;
                return guard;
            }
        }
        static void Main(string[] args)
        {
            Guardable<int> guardable = new Guardable<int>(5);
            using (var guard = guardable.Guard(10))
            {
                Console.WriteLine(guardable.Value);
            }
            Console.WriteLine(guardable.Value);
        }
    }
