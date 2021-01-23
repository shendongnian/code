    public class StackType<t>
    {
        public void Generate()
        {
        }
    }
    public class MyClass<T>
    {
        public MyClass(StackType<T> stack)
        {
            stack.Generate();
        }
    }
