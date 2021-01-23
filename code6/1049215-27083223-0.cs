    public class MyClass<T>
    {
        private readonly T item;
        public MyClass(T item)
        {
            this.item = item;
        }
        public void PrintItem()
        {
            Console.WriteLine(item.ToString());
        }
        public static implicit operator MyClass<T>(T d)
        {
            return new MyClass<T>(d);
        }
    }
