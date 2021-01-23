    static class Program
    {
        static void Main()
        {
            using (new DisposeMe("outer", new DisposeMe("inner", null)))
            {
                Console.WriteLine("inside using");
            }
            Console.WriteLine("after using scope");
        }
    }
    class DisposeMe : IDisposable
    {
        public readonly string name;
        public DisposeMe(string name, object dummy)
        {
            this.name = name;
        }
        public void Dispose()
        {
            Console.WriteLine("'Dispose' was called on instance named " + name);
        }
    }
