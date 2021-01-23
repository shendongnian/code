    public class ClassA<T> where T : IDisposable
    {
        public ClassA(T thing)
        {
            ThingA = thing;
        }
        public T ThingA { get; set; }
        public class ClassB
        {
            public ClassB(T thing)
            {
                ThingB = thing;
            }
            public T ThingB { get; set; }
        }
    }
