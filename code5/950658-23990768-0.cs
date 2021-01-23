    class Parent
    {
    }
    class Child : Parent
    {
        public void Foo()
        {
            var stack = new StackTrace();
            foreach (var frame in stack.GetFrames())
            {
                var methodInfo = frame.GetMethod();
                Console.WriteLine("{0} (ReflectedType: {1})", methodInfo.ToString(), methodInfo.DeclaringType);
            }
        }
    }
