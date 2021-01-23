    public class MyGenericHolder<T>
    {
        public MyGenericHolder()
        {
        }
    
        private T _theItem = default(T) ;
    
        public void Push(T item)
        {
            this._theItem = item;
        }
    
        public T Pop()
        {
            return this._theItem;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyGenericHolder<int> intHolder = new MyGenericHolder<int>();
                intHolder.Push(101);
                int x = intHolder.Pop();
                Console.WriteLine(x);
                MyGenericHolder<string> stringHolder = new MyGenericHolder<string>();
                stringHolder.Push("Hello Generics");
                string y = stringHolder.Pop();
                Console.WriteLine(y);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
    }
