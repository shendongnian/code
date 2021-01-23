        public static void Main()
        {
            MyClass<Myclass> other = new MyClass<Myclass>(new Myclass());
            List<int> intlist = new List<int>();
        }
        public class Myclass
        {
            public Myclass()
            {
            }
            public int i { get; set; }
        }
        public class MyClass<T> where T : Myclass
        {
            T value;
            public MyClass(T val)
            {
                value = val;
            }
        }
    }
