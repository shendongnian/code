    // Foo.debug.cs
        #if DEBUG
            partial class Foo
            {
                partial void Trace(string value)
                {
                    Console.WriteLine("The value is: {0}", value);
                }
            }
        #endif
    
    // Foo.cs
    partial class Foo
    {
        partial void Trace(string value);
        public void MethodWithTracing()
        {
            Trace("This is traced");
        }
    }
